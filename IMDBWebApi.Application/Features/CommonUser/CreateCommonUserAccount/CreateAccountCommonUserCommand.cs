using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.CommonUser.CreateCommonUserAccount;

public record CreateAccountCommonUserCommand(string Name, string UserName,
    string Email, string Password, DateTime Bithday) : IRequest<Result<CreateAccountCommonUserCommandResponse>>;
