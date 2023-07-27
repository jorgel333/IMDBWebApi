using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.CommonUser.Login;

public record LoginAccountUserCommand(string Email, string Password) : IRequest<Result<LoginAccountUserCommandResponse>>;
