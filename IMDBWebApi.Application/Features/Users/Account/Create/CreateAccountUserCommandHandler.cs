using FluentResults;
using IMDBWebApi.Application.Errors;
using IMDBWebApi.Application.Services.Cryptography;
using IMDBWebApi.Domain.Entities;
using IMDBWebApi.Domain.Interfaces;
using IMDBWebApi.Domain.Interfaces.Repositories;
using MediatR;

namespace IMDBWebApi.Application.Features.Users.Account.Create;

public class CreateAccountUserCommandHandler : IRequestHandler<CreateAccountUserCommand, Result<CreateAccountUserCommandResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly ICryptography _cryptography;
    private readonly IUnityOfWork _unityOfWork;

    public CreateAccountUserCommandHandler(IUserRepository userRepository, ICryptography cryptography, IUnityOfWork unityOfWork)
    {
        _userRepository = userRepository;
        _cryptography = cryptography;
        _unityOfWork = unityOfWork;
    }

    public async Task<Result<CreateAccountUserCommandResponse>> Handle(CreateAccountUserCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepository.IsUniqueEmail(request.Email, cancellationToken) is false)
            return Result.Fail(new ApplicationError("The email must be unique"));

        if (await _userRepository.IsUniqueUserName(request.UserName, cancellationToken) is false)
            return Result.Fail(new ApplicationError("The user name must be unique"));

        var salt = _cryptography.CreateSalt();
        var passwordHash = _cryptography.CryptographyPassword(request.Password, salt);

        var newUser = new User(request.Name,
            request.UserName,
            request.Email,
            passwordHash,
            salt,
            request.Bithday);

        _userRepository.Create(newUser);
        await _unityOfWork.SaveChangesAsync(cancellationToken);
        return Result.Ok(new CreateAccountUserCommandResponse(newUser.Id));
    }
}
