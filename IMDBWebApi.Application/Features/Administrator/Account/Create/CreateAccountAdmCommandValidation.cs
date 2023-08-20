using FluentValidation;
using IMDBWebApi.Application.Extension;
using IMDBWebApi.Domain.Interfaces.Repositories;

namespace IMDBWebApi.Application.Features.Administrator.Account.Create;

public class CreateAccountAdmCommandValidation : AbstractValidator<CreateAccountAdmCommand>
{
	public CreateAccountAdmCommandValidation(IAdministratorRepository admRepository)
	{
		RuleFor(x => x.Email)
			.MustAsync(admRepository.IsUniqueEmail).WithMessage("The email must be unique")
			.NotEmpty().WithMessage("Email is required")
			.EmailAddress().WithMessage("Invalid email format")
			.MaximumLength(256);

        RuleFor(x => x.UserName)
            .MustAsync(admRepository.IsUniqueUserName).WithMessage("The user name must be unique")
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
