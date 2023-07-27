using IMDBWebApi.Application.Features.Administrator.GetUsersDisable;
using IMDBWebApi.Domain.Interfaces.Repositories;
using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.Administrator.GetCommonUsersDisable;

public class GetCommonUsersDisableQueryHandler : IRequestHandler<GetCommonUsersDisableQuery, Result<IEnumerable<GetCommonUsersDisableQueryResponse>>>
{
    private readonly IUserRepository _commonUserRepository;

    public GetCommonUsersDisableQueryHandler(IUserRepository commonUserRepository)
    {
        _commonUserRepository = commonUserRepository;
    }

    public async Task<Result<IEnumerable<GetCommonUsersDisableQueryResponse>>> Handle(GetCommonUsersDisableQuery request, CancellationToken cancellationToken)
    {
        var inactiveUsers = await _commonUserRepository.GetAllDisable(cancellationToken);

        if (!inactiveUsers.Any())
            return Result.Ok(Enumerable.Empty<GetCommonUsersDisableQueryResponse>());

        return Result.Ok(inactiveUsers.Select(u => new GetCommonUsersDisableQueryResponse(u.Id, u.Name!, u.UserName!, u.Email!)));

    }
}
