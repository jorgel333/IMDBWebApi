using MediatR;
using FluentResults;

namespace IMDBWebApi.Application.Features.Administrator.Account.Create;

public record CreateAccountAdmCommand(string Name, string UserName, 
    string Email, string Password, DateTime bithday) : IRequest<Result<CreateAccountAdmCommandResponse>>;

