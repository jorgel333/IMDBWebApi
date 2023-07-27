using FluentResults;
using IMDBWebApi.Domain.Interfaces;
using IMDBWebApi.Domain.Interfaces.Repositories;
using MediatR;

namespace IMDBWebApi.Application.Features.CommonUser.Edit.UpdateRegistrationData;

public class UpdateRegistrationDataUserCommandHandler : IRequestHandler<UpdateRegistrationDataUserCommand, Result>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnityOfWork _unityOfWork;

    public UpdateRegistrationDataUserCommandHandler(IUserRepository userRepository, IUnityOfWork unityOfWork)
    {
        _userRepository = userRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<Result> Handle(UpdateRegistrationDataUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
        var anyEmailExists = await _userRepository.IsUniqueEmail(request.Email, cancellationToken);
        var anyUserNameExists = await _userRepository.IsUniqueUserName(request.UserName, cancellationToken);

        if (user is null)
            return Result.Fail("User not found");

        if (anyEmailExists)
            return Result.Fail("Email already used.");

        if (anyUserNameExists)
            return Result.Fail("UserName already used.");

        user.UpdateRegistrationData(request.Name, request.UserName, request.Email, request.BirthDay);
        _userRepository.Update(user);
        await _unityOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
