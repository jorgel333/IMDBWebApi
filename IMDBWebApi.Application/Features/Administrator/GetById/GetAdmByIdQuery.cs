using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.Administrator.GetById;

public record GetAdmByIdQuery(int Id) : IRequest<Result<GetAdmByIdQueryResponse>>;
