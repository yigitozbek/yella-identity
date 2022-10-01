using Yella.Domain.Dto;

namespace Yella.Identity.Service.Contract.Dtos;

public class RequestChangePasswordAsync : EntityDto<Guid>
{
    public string Username { get; set; }

    public string CurrentPassword { get; set; }

    public string ConfirmPassword { get; set; }

    public string NewPassword { get; set; }
}