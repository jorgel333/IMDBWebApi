using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.Administrator.Account.Login;

public record LoginAccountAdmCommand(string Email, string Password) : IRequest<Result<LoginAccountAdmResponse>>;

