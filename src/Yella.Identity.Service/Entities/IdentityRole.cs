using System.ComponentModel.DataAnnotations;
using Yella.Domain.Entities;

namespace Yella.Identity.Service.Entities;

public class IdentityRole<TUser, TRole> : FullAuditedEntity<Guid>
    where TUser : IdentityUser<TUser, TRole>
    where TRole : IdentityRole<TUser, TRole>
{
    public IdentityRole(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public IdentityRole()
    {
        
    }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [StringLength(250)]
    public string Description { get; set; } = null!;

    public virtual ICollection<IdentityUserRole<TUser, TRole>>? UserRoles { get; set; }
}