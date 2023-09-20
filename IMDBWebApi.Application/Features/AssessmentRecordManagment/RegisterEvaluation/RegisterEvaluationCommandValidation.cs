using FluentValidation;

namespace IMDBWebApi.Application.Features.AssessmentRecordManagment.RegisterEvaluation;

public class RegisterEvaluationCommandValidation : AbstractValidator<RegisterEvaluationCommand>
{
    public RegisterEvaluationCommandValidation()
    {
        RuleFor(x => x.Rate).InclusiveBetween(0, 10).WithMessage("Rating must be between 0 and 10.");

        RuleFor(x => x.CommonUserId).GreaterThan(0);

        RuleFor(x => x.MovieId).GreaterThan(0);

    }
}
