using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.CommonUser.Edit.UpdatePassword;

public record UpdatePasswordUserCommand(int Id, string Password, string ConfirmPassword) : IRequest<Result>;
