using FluentResults;
using IMDBWebApi.Application.Errors;
using IMDBWebApi.Application.UserInfo;
using IMDBWebApi.Domain.Interfaces;
using IMDBWebApi.Domain.Interfaces.Repositories;
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
            return Result.Fail(new ApplicationNotFoundError("Admin doesn't exist."));

        adm.UpdateRegistrationData(request.Name, request.UserName, request.Email, request.BirthDay);
        _admRepository.Update(adm);
        await _unityOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Ok();
    }
}
