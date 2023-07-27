using FluentResults;
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
            return Result.Fail("Admin doesn't exist.");

        if (await _admRepository.IsUniqueUserName(request.UserName, cancellationToken) is false)
            return Result.Fail("User name is not unique.");
        
        if (await _admRepository.IsUniqueEmail(request.Email, cancellationToken) is false)
            return Result.Fail("Email is not unique.");

        adm.UpdateRegistrationData(request.Name, request.UserName, request.Email, request.BirthDay);
        _admRepository.Update(adm);
        await _unityOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Ok();
    }
}
