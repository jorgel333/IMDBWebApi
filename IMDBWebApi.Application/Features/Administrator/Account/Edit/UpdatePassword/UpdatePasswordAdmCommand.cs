using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.Administrator.Account.Edit.UpdatePassword;

public record UpdatePasswordAdmCommand(string Password, string ConfirmPassword) : IRequest<Result>;
