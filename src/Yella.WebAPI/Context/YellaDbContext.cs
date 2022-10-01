using Microsoft.EntityFrameworkCore;
using Yella.Identity.Service.Context;
using Yella.WebAPI.Entities;

namespace Yella.WebAPI.Context;

public class YellaDbContext : YellaIdentityDbContext<YellaDbContext, User, Role>
{
    public YellaDbContext(DbContextOptions<YellaDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options, httpContextAccessor)
    {

    }
}

