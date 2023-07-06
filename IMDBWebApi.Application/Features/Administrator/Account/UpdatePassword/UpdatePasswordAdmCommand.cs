using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.Administrator.Account.UpdatePassword;

public record UpdatePasswordAdmCommand(string Password, string ConfirmPassword) : IRequest<Result>;
