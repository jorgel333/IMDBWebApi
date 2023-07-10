using IMDBWebApi.Application.Features.Administrator.GetCommonUsersDisable;
using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.Administrator.GetUsersDisable;

public record GetCommonUsersDisableQuery() : IRequest<Result<IEnumerable<GetCommonUsersDisableQueryResponse>>>;

