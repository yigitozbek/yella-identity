using Yella.Domain.Dto;

namespace Yella.Identity.Service.Contract.Dtos;

public class RequestRoleAddUserRole : EntityDto
{
    public RequestRoleAddUserRole(Guid userId, Guid roleId)
    {
        UserId = userId;
        RoleId = roleId;
    }

    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
}