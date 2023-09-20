using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.Users.Account.Disable;

public record DisableAccountUserCommand(int Id) : IRequest<Result>;
