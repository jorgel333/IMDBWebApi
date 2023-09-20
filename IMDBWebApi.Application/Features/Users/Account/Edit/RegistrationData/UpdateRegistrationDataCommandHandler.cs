using FluentResults;
using IMDBWebApi.Application.Errors;
using IMDBWebApi.Domain.Interfaces;
using IMDBWebApi.Domain.Interfaces.Repositories;
using MediatR;

namespace IMDBWebApi.Application.Features.Users.Account.Edit.RegistrationData;

public class UpdateRegistrationDataCommandHandler : IRequestHandler<UpdateRegistrationDataAccountUserCommand, Result>
{
    private readonly IUserRepository _userRespository;
    private readonly IUnityOfWork _unityOfWork;

    public UpdateRegistrationDataCommandHandler(IUserRepository userRespository, IUnityOfWork unityOfWork)
    {
        _userRespository = userRespository;
        _unityOfWork = unityOfWork;
    }

    public async Task<Result> Handle(UpdateRegistrationDataAccountUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRespository.GetByIdAsync(request.Id, cancellationToken);

        if (user is null)
            return Result.Fail(new ApplicationNotFoundError("User not found."));

        if (user.UserName != request.UserName)
            if (await _userRespository.IsUniqueUserName(request.UserName, cancellationToken) is false)
                return Result.Fail(new ApplicationError("UserName must be unique"));

        if (user.Email != request.Email)
            if (await _userRespository.IsUniqueEmail(request.Email, cancellationToken) is false)
                return Result.Fail(new ApplicationError("Email must be unique"));

        user.UpdateRegistrationData(request.Name, request.UserName, request.Email, request.BirthDay);
        _userRespository.Update(user);
        await _unityOfWork.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
