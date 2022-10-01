using System.ComponentModel.DataAnnotations;
using Yella.Domain.Entities;

namespace Yella.Identity.Service.Entities;

public class IdentityUser<TUser, TRole> : FullAuditedEntity<Guid>
    where TUser : IdentityUser<TUser, TRole>
    where TRole : IdentityRole<TUser, TRole>
{

    public IdentityUser(string username, string email, byte[] passwordSalt, byte[] passwordHash, string name, string surname)
    {
        
        Username = username;
        Email = email;
        PasswordSalt = passwordSalt;
        PasswordHash = passwordHash;

        Name = name;
        Surname = surname;
    }

    public IdentityUser()
    {

    }

    [Required, MinLength(3), MaxLength(20)]
    public string Username { get; set; } = null!;

    [Required, MinLength(5), EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    public byte[] PasswordSalt { get; set; } = null!;

    [Required]
    public byte[] PasswordHash { get; set; } = null!;

    [Required, MinLength(5), MaxLength(50)]
    public string Name { get; set; } = null!;

    [Required, MinLength(5), MaxLength(50)]
    public string Surname { get; set; } = null!;

    public virtual ICollection<IdentityUserRole<TUser, TRole>>? IdentityUserRoles { get; set; }

}
