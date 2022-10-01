using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Yella.EntityFrameworkCore.Context;
using Yella.Identity.Service.Entities;

namespace Yella.Identity.Service.Context;

public class YellaIdentityDbContext<TContext, TUser, TRole> : YellaDbContext<TContext>
    where TContext : DbContext
    where TUser : IdentityUser<TUser, TRole>
    where TRole : IdentityRole<TUser, TRole>
{


    public YellaIdentityDbContext(DbContextOptions<TContext> options, IHttpContextAccessor httpContextAccessor) : base(options, httpContextAccessor)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.NavigationBaseIncludeIgnored));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Identity");

        modelBuilder.Entity<TUser>(b =>
        {
            b.HasKey(u => u.Id);
            b.HasIndex(u => u.Username).IsUnique();

            b.HasIndex(u => u.Email).IsUnique();
        });

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<TUser> Users { get; set; }
    public DbSet<TRole> Roles { get; set; }
    public DbSet<IdentityUserRole<TUser, TRole>> IdentityUserRoles { get; set; }
    public DbSet<IdentityPermission<TUser, TRole>> IdentityPermissions { get; set; }
    public DbSet<IdentityPermissionRole<TUser, TRole>> IdentityPermissionRoles { get; set; }

    
}

