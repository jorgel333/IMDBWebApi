using IMDBWebApi.Application.Extension;
using FluentValidation;

namespace IMDBWebApi.Application.Features.Users.Account.Edit.Password;

public class UpdatePasswordAccountUserCommandValidator : AbstractValidator<UpdatePasswordAccountUserCommand>
{
    public UpdatePasswordAccountUserCommandValidator()
    {
        RuleFor(x => x.Password)
        .NotEmpty().WithMessage("{PropertyName} is required.")
        .MinimumLength(8).WithMessage("{PropertyName} must have at least 8 characters.")
        .Must(x => x.IsValidPassword())
        .WithMessage("{PropertyName} must contain at least one letter, one number, and one special character.");

        RuleFor(x => x.ConfirmPassword).Equal(x => x.Password);
    }
}
