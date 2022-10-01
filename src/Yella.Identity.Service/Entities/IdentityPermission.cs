using System.ComponentModel.DataAnnotations;
using Yella.Domain.Entities;

namespace Yella.Identity.Service.Entities;

public   class IdentityPermission<TUser, TRole> : FullAuditedEntity<short>
    where TUser : IdentityUser<TUser, TRole>
    where TRole : IdentityRole<TUser, TRole>
{
    [Required, MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    [Required, MaxLength(150)]
    public string Description { get; set; } = string.Empty;

    [Required, MaxLength(50)]
    public string Module { get; set; } = string.Empty;

    public virtual ICollection<IdentityPermissionRole<TUser, TRole>>  IdentityPermissionRoles { get; set; }
}