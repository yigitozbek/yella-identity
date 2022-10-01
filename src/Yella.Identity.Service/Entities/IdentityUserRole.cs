using System.ComponentModel.DataAnnotations.Schema;
using Yella.Domain.Entities;

namespace Yella.Identity.Service.Entities;

public class IdentityUserRole<TUser, TRole> : FullAuditedEntity<Guid>
    where TUser : IdentityUser<TUser, TRole>
    where TRole : IdentityRole<TUser, TRole>
{
    public IdentityUserRole(Guid identityUserId, Guid identityRoleId)
    {
        IdentityUserId = identityUserId;
        IdentityRoleId = identityRoleId;
    }

    public IdentityUserRole()
    {

    }

    [ForeignKey(nameof(IdentityUserId))]
    public virtual TUser? IdentityUser { get; set; }
    public Guid IdentityUserId { get; set; }


    [ForeignKey(nameof(IdentityRoleId))]
    public virtual TRole? IdentityRole { get; set; }
    public Guid IdentityRoleId { get; set; }

}