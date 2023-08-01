using FluentValidation;

namespace IMDBWebApi.Application.Features.Administrator.Account.Edit.UpdatePassword;
using IMDBWebApi.Application.Extension;
public class UpdatePasswordAdmCommandValidation : AbstractValidator<UpdatePasswordAdmCommand>
{
	public UpdatePasswordAdmCommandValidation()
	{
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MinimumLength(8).WithMessage("{PropertyName} must have at least 8 characters.")
            .Must(x => x.IsValidPassword())
            .WithMessage("{PropertyName} must contain at least one letter, one number, and one special character.");

        RuleFor(x => x.ConfirmPassword).Equal(x => x.Password);
    }
}
