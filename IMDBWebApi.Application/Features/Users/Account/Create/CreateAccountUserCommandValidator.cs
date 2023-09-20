using IMDBWebApi.Application.Extension;
using FluentValidation;

namespace IMDBWebApi.Application.Features.Users.Account.Create;

public class CreateAccountUserCommandValidator : AbstractValidator<CreateAccountUserCommand>
{
	public CreateAccountUserCommandValidator()
	{
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format")
            .MaximumLength(256);

        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("This field cannot be empty")
            .MinimumLength(4).MaximumLength(36);

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(8).WithMessage("Password must have at least 8 characters.")
            .Must(x => x.IsValidPassword())
            .WithMessage("Password must contain at least one letter, one number, and one special character.");

        RuleFor(x => x.Bithday)
            .NotEmpty().WithMessage("This field cannot be empty")
            .LessThan(DateTime.Now.Date);
    }
}
