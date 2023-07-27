using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.CommonUser.Edit.UpdateRegistrationData;

public record UpdateRegistrationDataUserCommand(int Id, string Name, string UserName,
    string Email, DateTime BirthDay) : IRequest<Result>;
