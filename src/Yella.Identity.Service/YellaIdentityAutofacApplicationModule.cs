using Autofac;
using Microsoft.EntityFrameworkCore;
using Yella.EntityFrameworkCore.Context;
using Yella.Identity.Service.Context;
using Yella.Identity.Service.Contract.Interfaces;
using Yella.Identity.Service.Entities;
using Yella.Identity.Service.Helpers.Security.JWT;
using Yella.Identity.Service.Managers;
using Yella.Identity.Service.Services;
using Yella.Utilities.Security.Hashing;

namespace Yella.Identity.Service;

public class YellaIdentityAutofacApplicationModule<TContext, TUser, TRole> : Module
    where TContext : DbContext
    where TUser : IdentityUser<TUser, TRole>
    where TRole : IdentityRole<TUser, TRole>
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<YellaIdentityDbContext<TContext, TUser, TRole>>();
        builder.RegisterType<AuthManager<TUser, TRole>>();
        builder.RegisterType<PasswordHasher>().As<IPasswordHasher>();
        builder.RegisterType<JwtHelper<TUser, TRole>>().As<ITokenHelper<TUser, TRole>>();

        builder.RegisterType<AuthApplicationService<TUser, TRole>>().As<IAuthService>();




        base.Load(builder);
    }

}