using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.Users.Account.Edit.RegistrationData;

public record UpdateRegistrationDataAccountUserCommand (int Id, string Name, string UserName,
    string Email, DateTime BirthDay) : IRequest<Result>;
public record UpdateRegistrationDataUserRequest(string Name, string UserName,
    string Email, DateTime BirthDay);
