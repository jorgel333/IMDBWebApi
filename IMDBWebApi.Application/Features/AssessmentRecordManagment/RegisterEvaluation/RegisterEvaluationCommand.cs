using FluentResults;
using MediatR;

namespace IMDBWebApi.Application.Features.AssessmentRecordManagment.RegisterEvaluation;

public record RegisterEvaluationCommand(int MovieId, int CommonUserId, int Rate) : IRequest<Result<RegisterEvaluationCommandResponse>>;
