using IMDBWebApi.Domain.Interfaces.Repositories;
using IMDBWebApi.Domain.Interfaces;
using FluentResults;
using MediatR;
using IMDBWebApi.Application.UserInfo;

namespace IMDBWebApi.Application.Features.Administrator.Account.Disable;

public class DisableAccountAdmCommandHander : IRequestHandler<DisableAccountAdmCommand, Result>
{
    private readonly IAdministratorRepository _admRepository;
    private readonly IUnityOfWork _unityOfWork;
    private readonly IUserInfo _userInfo;

    public DisableAccountAdmCommandHander(IAdministratorRepository admRepository, 
        IUnityOfWork unityOfWork, IUserInfo userInfo)
    {
        _admRepository = admRepository;
        _unityOfWork = unityOfWork;
        _userInfo = userInfo;
    }

    public async Task<Result> Handle(DisableAccountAdmCommand request, CancellationToken cancellationToken)
    {
        var adm = await _admRepository.GetByIdAsync(_userInfo.Id, cancellationToken);

        if (adm is null)
            return Result.Fail("Admin doesn't exist.");

        if (adm.IsDeleted is true)
            return Result.Fail("Admin already deactivated.");

        adm.SoftDelete();
        _admRepository.Update(adm);
        await _unityOfWork.SaveChangesAsync(cancellationToken);
        return Result.Ok();
    }
}
