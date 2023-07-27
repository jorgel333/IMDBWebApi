using FluentResults;
using IMDBWebApi.Application.Services.Cryptography;
using IMDBWebApi.Domain.Interfaces;
using IMDBWebApi.Domain.Interfaces.Repositories;
using MediatR;

namespace IMDBWebApi.Application.Features.CommonUser.Edit.UpdatePassword;

public class UpdatePasswordUserCommandHandler : IRequestHandler<UpdatePasswordUserCommand, Result>
{
    private readonly IUserRepository _commonUserRepository;
    private readonly ICryptography _cryptography;
    private readonly IUnityOfWork _unityOfWork;

    public UpdatePasswordUserCommandHandler(IUserRepository commonUserRepository, 
        ICryptography cryptography, IUnityOfWork unityOfWork)
    {
        _commonUserRepository = commonUserRepository;
        _cryptography = cryptography;
        _unityOfWork = unityOfWork;
    }

    public async Task<Result> Handle(UpdatePasswordUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _commonUserRepository.GetByIdAsync(request.Id, cancellationToken);

        if (user is null)
            return Result.Fail("User not found.");

        if (request.Password != request.ConfirmPassword)
            return Result.Fail("Different passwords");

        var salt = _cryptography.CreateSalt();
        var passwordHashSalt = _cryptography.CryptographyPassword(request.Password, salt);

        user.UpdatePassword(passwordHashSalt, salt);
        _commonUserRepository.Update(user);
        await _unityOfWork.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}
