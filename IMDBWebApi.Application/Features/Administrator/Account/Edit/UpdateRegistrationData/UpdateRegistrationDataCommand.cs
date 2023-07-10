using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.Administrator.Account.Edit.UpdateRegistrationData;

public record UpdateRegistrationDataCommand(string Name, string UserName, 
    string Email, DateTime BirthDay) : IRequest<Result>;
