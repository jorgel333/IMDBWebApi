using FluentResults;
using IMDBWebApi.Application.Errors;
using IMDBWebApi.Application.Features.Administrator.Account.Login;
using IMDBWebApi.Application.Services.Cryptography;
using IMDBWebApi.Application.Services.Token;
using IMDBWebApi.Domain.Interfaces.Repositories;
using MediatR;

namespace IMDBWebApi.Application.Features.Users.Account.Login;

public class LoginAccountUserCommandHandler : IRequestHandler<LoginAccountUserCommand, Result<LoginAccountUserCommandResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService  _tokenService;
    private readonly ICryptography _cryptography;

    public LoginAccountUserCommandHandler(IUserRepository userRepository, ITokenService tokenService,
        ICryptography cryptography)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
        _cryptography = cryptography;
    }

    public async Task<Result<LoginAccountUserCommandResponse>> Handle(LoginAccountUserCommand request, CancellationToken cancellationToken)
    {
        var userEmail = await _userRepository.GetByEmail(request.Email, cancellationToken);

        if (userEmail is null)
            return Result.Fail(new ApplicationError("Invalid email or password."));

        if (userEmail.IsDeleted == true)
            return Result.Fail(new ApplicationError("Admin disable."));

        var verifyPassword = _cryptography.VerifyPassword(userEmail!.PasswordHashSalt!, userEmail.PasswordSalt!, request.Password);

        if (verifyPassword is false)
            return Result.Fail(new ApplicationError("Invalid email or password."));

        var token = _tokenService.GenerateToken(userEmail);

        return Result.Ok(new LoginAccountUserCommandResponse(token));
    }
}
