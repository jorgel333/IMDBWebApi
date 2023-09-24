using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.Users.GetCommonUsersActive;

public record GetCommonUsersActiveQuery() : IRequest<Result<IEnumerable<GetCommonUsersActiveQueryResponse>>>;

