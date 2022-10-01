using Yella.Domain.Dto;

namespace Yella.Identity.Service.Contract.Dtos;

public class RequestDeleteUserRole : EntityDto
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
}