using Yella.Domain.Dto;

namespace Yella.Identity.Service.Contract.Dtos;

public class RequestAddRolePermission : EntityDto
{
    public Guid RoleId { get; set; }
    public short PermissionId { get; set; }
}
