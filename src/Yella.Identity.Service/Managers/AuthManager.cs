using System.Security.Claims;
using Yella.EntityFrameworkCore;
using Yella.EntityFrameworkCore.Extensions;
using Yella.Identity.Service.Const;
using Yella.Identity.Service.Contract.Dtos;
using Yella.Identity.Service.Entities;
using Yella.Identity.Service.Helpers.Security;
using Yella.Identity.Service.Helpers.Security.JWT;
using Yella.Utilities.Results;
using Yella.Utilities.Security.Hashing;

namespace Yella.Identity.Service.Managers;

public class AuthManager<TUser, TRole>
where TUser : IdentityUser<TUser, TRole>
where TRole : IdentityRole<TUser, TRole>
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly ITokenHelper<TUser, TRole> _tokenHelper;
    private readonly IRepository<IdentityUser<TUser, TRole>> _userRepository;
    private readonly IRepository<IdentityUserRole<TUser, TRole>, Guid> _userRoleRepository;
    private readonly IRepository<IdentityPermission<TUser, TRole>> _permissionRepository;
    public AuthManager(IPasswordHasher passwordHasher, ITokenHelper<TUser, TRole> tokenHelper, IRepository<IdentityUser<TUser, TRole>> userRepository, IRepository<IdentityUserRole<TUser, TRole>, Guid> userRoleRepository, IRepository<IdentityPermission<TUser, TRole>> permissionRepository)
    {
        _passwordHasher = passwordHasher;
        _tokenHelper = tokenHelper;
        _userRepository = userRepository;
        _userRoleRepository = userRoleRepository;
        _permissionRepository = permissionRepository;
    }


    public async Task<IResult> RegisterAsync(RequestRegister input)
    {

        var isUserExit = await _userRepository.FirstOrDefaultAsync(x => x.Username == input.Username || x.Email == input.Email);

        if (isUserExit != null)
        {
            return new ErrorResult("there is a user with a username or email");
        }

        _passwordHasher.CreatePasswordHash(input.Password, out var passwordHash, out var passwordSalt);

        var user = new IdentityUser<TUser, TRole>(input.Username, input.Email, passwordSalt, passwordHash, input.Name, input.Surname);

        var userResult = await _userRepository.AddAsync(user);

        var userRoleList = input.RoleIds.Select(registerDtoRoleId => new IdentityUserRole<TUser, TRole>(userResult.Data.Id, registerDtoRoleId)).ToList();

        var result = await _userRoleRepository.AddRangeAsync(userRoleList);

        if (!result.Success)
        {
            return new ErrorResult(result.Message);
        }

        return new SuccessResult(result.Message);
    }

    public async Task<IDataResult<AccessToken>> LoginAsync(RequestLogin input)
    {
        if (input == null) throw new ArgumentNullException(nameof(input));

        var user = await _userRepository.FirstOrDefaultAsync(x => x.Username == input.Username);

        if (user == null)
        {
            return new ErrorDataResult<AccessToken>(IdentityMessages.UserNotFound);
        }

        if (!VerifyPasswordHash(user, input.Password))
        {
            return new ErrorDataResult<AccessToken>(IdentityMessages.PasswordError);
        }

        var accessToken = await CreateTokenAsync(user.Id, null);

        return new SuccessDataResult<AccessToken>(accessToken, IdentityMessages.Successful);

    }


    public async Task<IResult> ChangePasswordAsync(RequestChangePasswordAsync input)
    {
        if (input == null) throw new ArgumentNullException(nameof(input));

        var user = await _userRepository.FirstOrDefaultAsync(x => x.Id == input.Id);

        if (user == null)
        {
            return new ErrorResult("there is no such user");
        }

        if (!_passwordHasher.VerifyPasswordHash(input.CurrentPassword, user.PasswordHash, user.PasswordSalt))
        {
            return new ErrorResult(IdentityMessages.ThisPasswordIsWrong);
        }

        _passwordHasher.CreatePasswordHash(input.NewPassword, out var passwordHash, out var passwordSalt);

        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        var result = await _userRepository.UpdateAsync(user);

        if (!result.Success)
        {
            return new ErrorResult(result.Message);
        }

        return new SuccessResult(result.Message);
    }


    /// <summary>
    /// This method checks the correctness of the password.
    /// </summary>
    /// <param name="user"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    private bool VerifyPasswordHash(IdentityUser<TUser, TRole> user, string password) => _passwordHasher.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt);



    /// <summary>
    /// This method is a Private method. It is used to create tokens.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="claims"></param>
    /// <returns></returns>
    private async Task<AccessToken> CreateTokenAsync(Guid userId, IEnumerable<Claim>? claims)
    {
        var user = await _userRepository.GetAsync(userId);

        var roles = (await _userRoleRepository.WithIncludeAsync(x => x.IdentityRole!)).Where(x => x.IdentityUserId == user.Id).Select(x => x.IdentityRole);

        var permissions = (await _permissionRepository.WithIncludeAsync(x => x.IdentityPermissionRoles,
                x => ((IdentityPermissionRole<TUser,TRole>)x.IdentityPermissionRoles).IdentityRole!,
                x => ((IdentityPermissionRole<TUser,TRole>)x.IdentityPermissionRoles).IdentityRole!.UserRoles!))
            .Where(x => x.IdentityPermissionRoles.Any(pRole => pRole.IdentityRole!.UserRoles!.Any(uRole => uRole.IdentityUserId == userId)));

        var accessToken = _tokenHelper.CreateToken(user, roles, permissions, claims);

        return accessToken;
    }

}
