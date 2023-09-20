using FluentResults;
using IMDBWebApi.Application.Errors;
using IMDBWebApi.Application.Services.Cryptography;
using IMDBWebApi.Domain.Interfaces;
using IMDBWebApi.Domain.Interfaces.Repositories;
using MediatR;

namespace IMDBWebApi.Application.Features.Users.Account.Edit.Password;

public class UpdatePasswordAccountUserCommandHandler : IRequestHandler<UpdatePasswordAccountUserCommand, Result>
{
    private readonly IUserRepository _userRepository;
    private readonly ICryptography _cryptography;
    private readonly IUnityOfWork _unityOfWork;

    public UpdatePasswordAccountUserCommandHandler(IUserRepository userRepository, ICryptography cryptography, IUnityOfWork unityOfWork)
    {
        _userRepository = userRepository;
        _cryptography = cryptography;
        _unityOfWork = unityOfWork;
    }

    public async Task<Result> Handle(UpdatePasswordAccountUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

        if (user is null)
            return Result.Fail(new ApplicationNotFoundError("User not found"));

        var newSalt = _cryptography.CreateSalt();
        var newPassword = _cryptography.CryptographyPassword(request.Password, newSalt);

        user.UpdatePassword(newPassword, newSalt);
        _userRepository.Update(user);
        await _unityOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
