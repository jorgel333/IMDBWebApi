using FluentResults;
using IMDBWebApi.Application.Errors;
using IMDBWebApi.Domain.Interfaces;
using IMDBWebApi.Domain.Interfaces.Repositories;
using MediatR;

namespace IMDBWebApi.Application.Features.Users.Account.Disable;

public class DisableAccountUserCommandHandler : IRequestHandler<DisableAccountUserCommand, Result>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnityOfWork _unityOfWork;

    public DisableAccountUserCommandHandler(IUserRepository userRepository, IUnityOfWork unityOfWork)
    {
        _userRepository = userRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<Result> Handle(DisableAccountUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

        if (user is null)
            return Result.Fail(new ApplicationNotFoundError("User not found"));

        if (user.IsDeleted == true)
            return Result.Fail(new ApplicationError("User already deactivated."));

        user.SoftDelete();
        
        _userRepository.Update(user);
        await _unityOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
