using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.Administrator.Account.Edit.UpdatePassword;

public record UpdatePasswordAdmCommand(int Id, string Password, string ConfirmPassword) : IRequest<Result>;
public record UpdatePasswordAdmRequest(string Password, string ConfirmPassword);
