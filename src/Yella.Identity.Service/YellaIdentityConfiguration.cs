using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Yella.EntityFrameworkCore.IoC.DependencyResolvers;
using Yella.Identity.Service.Entities;
using Yella.Identity.Service.Helpers.Security.JWT;
using Yella.Utilities.Extensions;

namespace Yella.Identity.Service;

public static class YellaIdentityConfiguration
{

    public static IServiceCollection AddIdentityApplicationService<TUser, TRole>(this IServiceCollection services)
        where TUser : IdentityUser<TUser, TRole>
        where TRole : IdentityRole<TUser, TRole>
    {

        #region cors
        services.AddCors(options =>
        {
            options.AddPolicy("AllCors", policy =>
            {
                policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });
        });
        #endregion

        #region AutoMapper
        services.AddAutoMapper(typeof(YellaIdentityAutoMapper<TUser, TRole>).Assembly);
        #endregion

        services.AddHttpContextAccessor();

        return services;
    }

    public static IServiceCollection AddIdentityService<TUser, TRole>(this IServiceCollection services, WebApplicationBuilder builder)
        where TUser : IdentityUser<TUser, TRole>
        where TRole : IdentityRole<TUser, TRole>

    {
        #region Identity


        var tokenOptions = builder.Configuration.GetSection("TokenOptions")
            .Get<JwtHelper<TUser, TRole>.TokenOptions>();

        var sessionOption = builder.Configuration.GetSection("SessionOption")
            .Get<JwtHelper<TUser, TRole>.SessionOption>();

        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(sessionOption.IdleTimeout);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateLifetime = false,
                    ValidateAudience = true,
                    ValidAudience = tokenOptions.Audience,
                    ValidIssuer = tokenOptions.Issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey)),
                    ValidateIssuer = true,
                };
            });

        #endregion

        return services;
    }

    public static IServiceCollection AddContextService(this IServiceCollection services, string connectionString)
    {
        return services;
    }

    public static ConfigureHostBuilder AddIdentityApplicationHost<TContext, TUser, TRole>(this ConfigureHostBuilder host)
        where TContext : DbContext
        where TUser : IdentityUser<TUser, TRole>
        where TRole : IdentityRole<TUser, TRole>
    {

        #region Autofac

        host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

        host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
            containerBuilder.RegisterModule(new YellaIdentityAutofacApplicationModule<TContext, TUser, TRole>()));

        host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
            containerBuilder.RegisterModule(new AutofacEntityFrameworkCoreModule()));


        #endregion

        return host;
    }

    public static WebApplication UseIdentityApplication(this WebApplication app)
    {
        ServiceActivator.Configure(app.Services);

        return app;
    }

}