using FluentResults;
using IMDBWebApi.Application.Errors;
using IMDBWebApi.Application.UserInfo;
using IMDBWebApi.Domain.Interfaces.Repositories;
using MediatR;

namespace IMDBWebApi.Application.Features.Administrator.GetById;

public class GetAdmByIdQueryHandler : IRequestHandler<GetAdmByIdQuery, Result<GetAdmByIdQueryResponse>>
{
    private readonly IAdministratorRepository _admRepository;

    public GetAdmByIdQueryHandler(IAdministratorRepository admRepository)
    {
        _admRepository = admRepository;
    }
    public async Task<Result<GetAdmByIdQueryResponse>> Handle(GetAdmByIdQuery request, CancellationToken cancellationToken)
    {
        var adm = await _admRepository.GetByIdAsync(request.Id, cancellationToken);

        if (adm is null)
            return Result.Fail(new ApplicationNotFoundError("Adm not found"));

        return Result.Ok(new GetAdmByIdQueryResponse(adm.Id, adm.Name!, adm.UserName!, adm.IsDeleted));
    }
}
