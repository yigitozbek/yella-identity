using Yella.Identity.Service.Contract.Dtos;
using Yella.Identity.Service.Contract.Interfaces;
using Yella.Identity.Service.Entities;
using Yella.Identity.Service.Managers;
using Yella.Utilities.Results;

namespace Yella.Identity.Service.Services;


public class AuthApplicationService<TUser,TRole> : IAuthService
    where TUser : IdentityUser<TUser, TRole>
    where TRole : IdentityRole<TUser, TRole>

{

    private readonly AuthManager<TUser, TRole> _authManager;


    public AuthApplicationService(AuthManager<TUser, TRole> authManager)
    {
        _authManager = authManager;
    }

    /// <summary>
    /// This method allows it to be registered to the User table.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<IResult> RegisterAsync(RequestRegister input)
    {
        var result = await _authManager.RegisterAsync(input);

        if (!result.Success)
        {
            return new ErrorResult(result.Message);
        }

        return new SuccessResult(result.Message);
    }



    /// <summary>
    /// This method is used for resetting the password.
    /// </summary>
    /// <param name="input"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<IResult> ChangePasswordAsync(RequestChangePasswordAsync input)
    {
        var result = await _authManager.ChangePasswordAsync(input);

        if (!result.Success)
        {
            return new ErrorResult(result.Message);
        }

        return new SuccessResult(result.Message);
    }


}