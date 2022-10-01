using Yella.Domain.Dto;

namespace Yella.Identity.Service.Contract.Dtos;

public class ResponseRoleGetList : EntityDto<Guid>
{
    public string Name { get; set; }

    public string Description { get; set; }
}