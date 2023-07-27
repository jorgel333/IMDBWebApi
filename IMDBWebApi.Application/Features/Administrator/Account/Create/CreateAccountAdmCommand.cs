using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.Administrator.Account.Create;

public record CreateAccountAdmCommand(string Name, string UserName, 
    string Email, string Password, DateTime Bithday) : IRequest<Result<CreateAccountAdmCommandResponse>>;

