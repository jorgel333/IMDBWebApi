using IMDBWebApi.Application.Services.Cryptography;
using IMDBWebApi.Domain.Interfaces.Repositories;
using IMDBWebApi.Application.Services.Token;
using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.Administrator.Account.Login;

public class LoginAccountAdmCommandHandler : IRequestHandler<LoginAccountAdmCommand, Result<LoginAccountAdmResponse>>
{
    private readonly IAdministratorRepository _admRepository;
    private readonly ITokenService _tokenService;
    private readonly ICryptography _cryptography;

    public LoginAccountAdmCommandHandler(IAdministratorRepository admRepository, 
        ITokenService tokenService, ICryptography cryptography)
    {
        _admRepository = admRepository;
        _tokenService = tokenService;
        _cryptography = cryptography;
    }

    public async Task<Result<LoginAccountAdmResponse>> Handle(LoginAccountAdmCommand request, CancellationToken cancellationToken)
    {
        var admEmail = await _admRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (admEmail is null)
            return Result.Fail("Login Invalid.");

        if (admEmail.IsDeleted == true)
            return Result.Fail("Admin disable.");

        if (_cryptography.VerifyPassword(admEmail.PasswordHashSalt!, 
            admEmail.PasswordSalt!, request.Password) is false)
            return Result.Fail("Login Invalid");

        var token = _tokenService.GenerateToken(admEmail);
        var refreshToken = _tokenService.GenerateRefreshToken();

        return Result.Ok(new LoginAccountAdmResponse(token, refreshToken));
    }
}
