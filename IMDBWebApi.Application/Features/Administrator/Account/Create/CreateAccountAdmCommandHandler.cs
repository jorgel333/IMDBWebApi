﻿using IMDBWebApi.Application.Services.Cryptography;
using IMDBWebApi.Domain.Interfaces.Repositories;
using IMDBWebApi.Domain.Interfaces;
using IMDBWebApi.Domain.Entities;
using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.Administrator.Account.Create;

public class CreateAccountAdmCommandHandler : IRequestHandler<CreateAccountAdmCommand, Result<CreateAccountAdmCommandResponse>>
{
    private readonly IAdministratorRepository _admRepository;
    private readonly IUnityOfWork _unityOfWork;
    private readonly ICryptography _cryptography;
    public CreateAccountAdmCommandHandler(IAdministratorRepository admRepository,
        IUnityOfWork unityOfWork, ICryptography cryptography)
    {
        _admRepository = admRepository;
        _unityOfWork = unityOfWork;
        _cryptography = cryptography;
    }
    public async Task<Result<CreateAccountAdmCommandResponse>> Handle(CreateAccountAdmCommand request, CancellationToken cancellationToken)
    {
        var salt = _cryptography.CreateSalt();
        var passwordHash = _cryptography.CryptographyPassword(request.Password, salt);

        var newAdm = new Admin(request.Name,
                        request.UserName,
                        request.Email,
                        passwordHash,
                        salt,
                        request.Bithday);

        _admRepository.CreateAdm(newAdm);
        await _unityOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Ok(new CreateAccountAdmCommandResponse(newAdm.Id));

    }
}
