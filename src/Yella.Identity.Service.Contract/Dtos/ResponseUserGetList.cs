using Yella.Domain.Dto;

namespace Yella.Identity.Service.Contract.Dtos;

public class ResponseUserGetList : EntityDto<Guid>
{
    public string Username { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;
}