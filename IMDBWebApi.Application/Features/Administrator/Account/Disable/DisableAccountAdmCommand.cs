using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.Administrator.Account.Disable;

public record DisableAccountAdmCommand() : IRequest<Result>;

