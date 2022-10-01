using System.ComponentModel.DataAnnotations;
using Yella.Identity.Service.Entities;

namespace Yella.WebAPI.Entities;

public class User : IdentityUser<User, Role>
{
    [Required]
    [MaxLength(15)]
    public string PhoneNumber { get; set; } = null!;
}