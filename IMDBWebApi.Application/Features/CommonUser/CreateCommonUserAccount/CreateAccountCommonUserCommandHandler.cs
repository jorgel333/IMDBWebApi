using IMDBWebApi.Application.Services.Cryptography;
using IMDBWebApi.Domain.Interfaces.Repositories;
using IMDBWebApi.Domain.Interfaces;
using IMDBWebApi.Domain.Entities;
using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.CommonUser.CreateCommonUserAccount;

public class CreateAccountCommonUserCommandHandler : IRequestHandler<CreateAccountCommonUserCommand, Result<CreateAccountCommonUserCommandResponse>>
{
    private readonly IUserRepository _commonUserRepository;
    private readonly ICryptography _cryptography;
    private readonly IUnityOfWork _unityOfWork;

    public CreateAccountCommonUserCommandHandler(IUserRepository commonUserRepository, 
        ICryptography cryptography, IUnityOfWork unityOfWork)
    {
        _commonUserRepository = commonUserRepository;
        _cryptography = cryptography;
        _unityOfWork = unityOfWork;
    }

    public async Task<Result<CreateAccountCommonUserCommandResponse>> Handle(CreateAccountCommonUserCommand request, CancellationToken cancellationToken)
    {
        var anyEmailExists = await _commonUserRepository.IsUniqueEmail(request.Email, cancellationToken);
        var anyUserNameExists = await _commonUserRepository.IsUniqueUserName(request.UserName, cancellationToken);

        if (anyEmailExists)
            return Result.Fail("Email already used.");

        if (anyUserNameExists)
            return Result.Fail("UserName already used.");

        var salt = _cryptography.CreateSalt();
        var passwordHash = _cryptography.CryptographyPassword(request.Password, salt);

        var newUser = new User(request.Name,
                        request.UserName,
                        request.Email,
                        passwordHash,
                        salt,
                        request.Bithday);

        _commonUserRepository.Create(newUser);
        await _unityOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok(new CreateAccountCommonUserCommandResponse(newUser.Id));
    }
}
