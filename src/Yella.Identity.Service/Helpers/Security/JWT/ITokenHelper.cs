using System.Security.Claims;
using Yella.Identity.Service.Entities;

namespace Yella.Identity.Service.Helpers.Security.JWT;

public interface ITokenHelper<TUser, TRole>
    where TUser : IdentityUser<TUser, TRole>
    where TRole : IdentityRole<TUser, TRole>
{
    AccessToken CreateToken(IdentityUser<TUser, TRole> user, IEnumerable<IdentityRole<TUser, TRole>> roles, IEnumerable<IdentityPermission<TUser, TRole>> permissions, IEnumerable<Claim>? claims);
}