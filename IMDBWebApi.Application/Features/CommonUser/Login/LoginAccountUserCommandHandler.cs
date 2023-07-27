using FluentResults;
using IMDBWebApi.Application.Features.Administrator.Account.Login;
using IMDBWebApi.Application.Services.Cryptography;
using IMDBWebApi.Application.Services.Token;
using IMDBWebApi.Domain.Interfaces.Repositories;
using MediatR;

namespace IMDBWebApi.Application.Features.CommonUser.Login;

public class LoginAccountUserCommandHandler : IRequestHandler<LoginAccountUserCommand, Result<LoginAccountUserCommandResponse>>
{
    private readonly IUserRepository _userRespository;
    private readonly ITokenService _tokenService;
    private readonly ICryptography _cryptography;

    public LoginAccountUserCommandHandler(IUserRepository userRespository, 
        ITokenService tokenService, ICryptography cryptography)
    {
        _userRespository = userRespository;
        _tokenService = tokenService;
        _cryptography = cryptography;
    }

    public async Task<Result<LoginAccountUserCommandResponse>> Handle(LoginAccountUserCommand request, CancellationToken cancellationToken)
    {
        var userEmail = await _userRespository.GetByEmail(request.Email, cancellationToken);

        if (userEmail is null)
            return Result.Fail("Login Invalid.");

        if (userEmail.IsDeleted == true)
            return Result.Fail("User disable.");

        if (_cryptography.VerifyPassword(userEmail.PasswordHashSalt!,
            userEmail.PasswordSalt!, request.Password) is false)
            return Result.Fail("Login Invalid");

        var token = _tokenService.GenerateToken(userEmail);
        var refreshToken = _tokenService.GenerateRefreshToken();

        return Result.Ok(new LoginAccountUserCommandResponse(token, refreshToken));
    }
}
