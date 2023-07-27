using IMDBWebApi.Application.Services.Cryptography;
using IMDBWebApi.Domain.Interfaces.Repositories;
using IMDBWebApi.Application.UserInfo;
using IMDBWebApi.Domain.Interfaces;
using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.Administrator.Account.Edit.UpdatePassword;

public class UpdatePasswordAdmCommandHandler : IRequestHandler<UpdatePasswordAdmCommand, Result>
{
    private readonly IAdministratorRepository _admRepository;
    private readonly IUnityOfWork _unityOfWork;
    private readonly ICryptography _cryptography;

    public UpdatePasswordAdmCommandHandler(IAdministratorRepository admRepository,
        IUnityOfWork unityOfWork, ICryptography cryptography)
    {
        _admRepository = admRepository;
        _unityOfWork = unityOfWork;
        _cryptography = cryptography;
    }
    public async Task<Result> Handle(UpdatePasswordAdmCommand request, CancellationToken cancellationToken)
    {
        var adm = await _admRepository.GetByIdAsync(request.Id, cancellationToken);

        if (adm is null)
            return Result.Fail("Admin doesn't exist.");

        if (request.Password != request.ConfirmPassword)
            return Result.Fail("Different passwords");


        var salt = _cryptography.CreateSalt();
        var passwordHash = _cryptography.CryptographyPassword(request.Password, salt);

        adm.UpdatePassword(passwordHash, salt);
        _admRepository.Update(adm);
        await _unityOfWork.SaveChangesAsync(cancellationToken);
        return Result.Ok();

    }
}
