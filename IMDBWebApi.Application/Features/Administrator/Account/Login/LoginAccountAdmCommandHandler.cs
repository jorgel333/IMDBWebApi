using IMDBWebApi.Application.Services.Cryptography;
using IMDBWebApi.Domain.Interfaces.Repositories;
using IMDBWebApi.Application.Services.Token;
using IMDBWebApi.Application.Errors;
using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.Administrator.Account.Login;

public class LoginAccountAdmCommandHandler : IRequestHandler<LoginAccountAdmCommand, Result<LoginAccountAdmCommandResponse>>
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

    public async Task<Result<LoginAccountAdmCommandResponse>> Handle(LoginAccountAdmCommand request, CancellationToken cancellationToken)
    {
        var admEmail = await _admRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (admEmail is null)
            return Result.Fail(new ApplicationError("Invalid email or password."));

        if (admEmail.IsDeleted == true)
            return Result.Fail(new ApplicationError("Admin disable."));
        
        var verifyPassword = _cryptography.VerifyPassword(admEmail.PasswordHashSalt!, admEmail.PasswordSalt!, request.Password);
        
        if (verifyPassword is false)
            return Result.Fail(new ApplicationError("Invalid email or password."));

        var token = _tokenService.GenerateToken(admEmail);

        return Result.Ok(new LoginAccountAdmCommandResponse(token));
    }
}
