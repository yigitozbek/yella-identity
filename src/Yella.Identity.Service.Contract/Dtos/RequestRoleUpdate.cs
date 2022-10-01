using Yella.Domain.Dto;

namespace Yella.Identity.Service.Contract.Dtos;

public class RequestRoleUpdate : EntityDto<Guid>
{
    public string Name { get; set; }

    public string Description { get; set; }
}
