using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.CommonUser.Disable;

public record DisableAccountUserCommand(int UserId) : IRequest<Result>;
