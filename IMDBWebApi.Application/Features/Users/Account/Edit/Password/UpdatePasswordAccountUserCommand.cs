using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.Users.Account.Edit.Password;

public record UpdatePasswordAccountUserCommand(int Id, string Password, string ConfirmPassword) : IRequest<Result>;
