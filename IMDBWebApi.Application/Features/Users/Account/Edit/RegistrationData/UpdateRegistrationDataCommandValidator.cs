using FluentValidation;

namespace IMDBWebApi.Application.Features.Users.Account.Edit.RegistrationData;

public class UpdateRegistrationDataCommandValidator : AbstractValidator<UpdateRegistrationDataAccountUserCommand>
{
    public UpdateRegistrationDataCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("This field cannot be empty")
            .EmailAddress().WithMessage("Invalid email format")
            .MaximumLength(256);

        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("This field cannot be empty")
            .MinimumLength(4).MaximumLength(36);

        RuleFor(x => x.BirthDay)
            .NotEmpty().WithMessage("This field cannot be empty")
            .LessThan(DateTime.Now.Date);
    }
}
