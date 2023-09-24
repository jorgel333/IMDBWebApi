using IMDBWebApi.Domain.Interfaces.Repositories;
using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.Users.GetCommonUsersActive;

public class GetCommonUsersActiveQueryHandler : IRequestHandler<GetCommonUsersActiveQuery, Result<IEnumerable<GetCommonUsersActiveQueryResponse>>>
{
    private readonly IUserRepository _commonUserRepository;

    public GetCommonUsersActiveQueryHandler(IUserRepository commonUserRepository)
    {
        _commonUserRepository = commonUserRepository;
    }

    public async Task<Result<IEnumerable<GetCommonUsersActiveQueryResponse>>> Handle(GetCommonUsersActiveQuery request, CancellationToken cancellationToken)
    {
        var activeUsers = await _commonUserRepository.GetAllActive(cancellationToken);

        if (activeUsers.Any() is false)
            return Result.Ok(Enumerable.Empty<GetCommonUsersActiveQueryResponse>());

        return Result.Ok(activeUsers.Select(u => new GetCommonUsersActiveQueryResponse(u.Id, u.Name!, u.UserName!, u.Email!)));

    }
}
