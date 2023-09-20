using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.Users.Account.Create;

public record CreateAccountUserCommand(string Name, string UserName,
    string Email, string Password, DateTime Bithday) : IRequest<Result<CreateAccountUserCommandResponse>>;
