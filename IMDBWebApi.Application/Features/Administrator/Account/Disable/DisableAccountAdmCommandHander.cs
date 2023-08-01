using IMDBWebApi.Domain.Interfaces.Repositories;
using IMDBWebApi.Application.UserInfo;
using IMDBWebApi.Domain.Interfaces;
using FluentResults;
using MediatR;
using IMDBWebApi.Application.Errors;

namespace IMDBWebApi.Application.Features.Administrator.Account.Disable;

public class DisableAccountAdmCommandHander : IRequestHandler<DisableAccountAdmCommand, Result>
{
    private readonly IAdministratorRepository _admRepository;
    private readonly IUnityOfWork _unityOfWork;

    public DisableAccountAdmCommandHander(IAdministratorRepository admRepository, 
        IUnityOfWork unityOfWork)
    {
        _admRepository = admRepository;
        _unityOfWork = unityOfWork;
    }

    public async Task<Result> Handle(DisableAccountAdmCommand request, CancellationToken cancellationToken)
    {
        var adm = await _admRepository.GetByIdAsync(request.Id, cancellationToken);

        if (adm is null)
            return Result.Fail(new ApplicationNotFoundError("Admin doesn't exist."));

        if (adm.IsDeleted == true)
            return Result.Fail(new ApplicationError("Admin already deactivated."));

        adm.SoftDelete();
        _admRepository.Update(adm);
        await _unityOfWork.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}
