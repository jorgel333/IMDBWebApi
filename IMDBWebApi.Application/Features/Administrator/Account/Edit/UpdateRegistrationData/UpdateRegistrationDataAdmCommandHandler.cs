using IMDBWebApi.Domain.Interfaces.Repositories;
using IMDBWebApi.Application.Errors;
using IMDBWebApi.Domain.Interfaces;
using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.Administrator.Account.Edit.UpdateRegistrationData;

public class UpdateRegistrationDataAdmCommandHandler : IRequestHandler<UpdateRegistrationDataAdmCommand, Result>
{
    private readonly IAdministratorRepository _admRepository;
    private readonly IUnityOfWork _unityOfWork;

    public UpdateRegistrationDataAdmCommandHandler(IAdministratorRepository admRepository, 
        IUnityOfWork unityOfWork)
    {
        _admRepository = admRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<Result> Handle(UpdateRegistrationDataAdmCommand request, CancellationToken cancellationToken)
    {
        var adm = await _admRepository.GetByIdAsync(request.Id, cancellationToken);
        
        if (adm is null)
            return Result.Fail(new ApplicationNotFoundError("Admin not found."));

        if (adm.UserName != request.UserName)
            if (await _admRepository.IsUniqueUserName(request.UserName, cancellationToken) is false)
                return Result.Fail(new ApplicationError("UserName must be unique"));

        if (adm.Email != request.Email)
            if (await _admRepository.IsUniqueEmail(request.Email, cancellationToken) is false)
                return Result.Fail(new ApplicationError("Email must be unique"));

        adm.UpdateRegistrationData(request.Name, request.UserName, request.Email, request.BirthDay);
        _admRepository.Update(adm);
        await _unityOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Ok();
    }
}
