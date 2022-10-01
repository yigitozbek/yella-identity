using Yella.Domain.Dto;

namespace Yella.Identity.Service.Contract.Dtos;

public class ResponsePermissionGetList : EntityDto<Guid>
{
    public string Name { get; set; }

    public string Description { get; set; }

    public string Module { get; set; }
}