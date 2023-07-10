using IMDBWebApi.Application.Features.Administrator.GetUsersDisable;
using FluentResults;
using MediatR;
using IMDBWebApi.Domain.Interfaces.Repositories;
using IMDBWebApi.Domain.Interfaces;

namespace IMDBWebApi.Application.Features.Administrator.GetCommonUsersDisable;

public class GetCommonUsersDisableQueryHandler : IRequestHandler<GetCommonUsersDisableQuery, Result<IEnumerable<GetCommonUsersDisableQueryResponse>>>
{
    private readonly ICommonUserRepository _commonUserRepository;

    public GetCommonUsersDisableQueryHandler(ICommonUserRepository commonUserRepository)
    {
        _commonUserRepository = commonUserRepository;
    }

    public async Task<Result<IEnumerable<GetCommonUsersDisableQueryResponse>>> Handle(GetCommonUsersDisableQuery request, CancellationToken cancellationToken)
    {
        var inactiveUsers = await _commonUserRepository.GetAllDisable(cancellationToken);

        if (!inactiveUsers.Any())
            return Result.Ok(Enumerable.Empty<GetCommonUsersDisableQueryResponse>());

        return Result.Ok(inactiveUsers.Select(u => new GetCommonUsersDisableQueryResponse(u.Id, u.Name!,
            u.UserName!, u.Email!)));

    }
}
