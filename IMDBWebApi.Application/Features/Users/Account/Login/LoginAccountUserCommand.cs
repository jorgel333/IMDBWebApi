using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.Users.Account.Login;

public record LoginAccountUserCommand (string Email, string Password, string ConfirmPassword) : IRequest<Result<LoginAccountUserCommandResponse>>;
