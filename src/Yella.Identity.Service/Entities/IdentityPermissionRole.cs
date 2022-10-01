using System.ComponentModel.DataAnnotations.Schema;
using Yella.Domain.Entities;

namespace Yella.Identity.Service.Entities;

public   class IdentityPermissionRole<TUser, TRole> : FullAuditedEntity<Guid>
    where TUser : IdentityUser<TUser, TRole>
    where TRole : IdentityRole<TUser, TRole>
{
    public IdentityPermissionRole(short identityPermissionId, Guid identityRoleId)
    {
        IdentityPermissionId = identityPermissionId;
        IdentityRoleId = identityRoleId;
    }

    public IdentityPermissionRole()
    {
        
    }

    [ForeignKey(nameof(IdentityPermissionId))]
    public virtual IdentityPermission<TUser, TRole>? IdentityPermission { get; set; }
    public short IdentityPermissionId { get; set; }

    [ForeignKey(nameof(IdentityRoleId))]
    public TRole? IdentityRole { get; set; }
    public Guid IdentityRoleId { get; set; }
}