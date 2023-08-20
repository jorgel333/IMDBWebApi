using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.Cast.Create;

public record CreateCastCommand (string Name, string Description, DateTime Birthday) : IRequest<Result<CreateCastCommandResponse>>;
