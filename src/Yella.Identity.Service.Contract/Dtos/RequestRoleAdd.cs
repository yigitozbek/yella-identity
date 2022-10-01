using Yella.Domain.Dto;

namespace Yella.Identity.Service.Contract.Dtos;

public class RequestRoleAdd : EntityDto
{
    public string Name { get; set; }

    public string Description { get; set; }
}
