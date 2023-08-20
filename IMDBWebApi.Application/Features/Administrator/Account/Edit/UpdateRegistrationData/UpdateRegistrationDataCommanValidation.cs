using IMDBWebApi.Domain.Interfaces.Repositories;
using FluentValidation;

namespace IMDBWebApi.Application.Features.Administrator.Account.Edit.UpdateRegistrationData;

public class UpdateRegistrationDataCommanValidation : AbstractValidator<UpdateRegistrationDataAdmCommand>
{
	public UpdateRegistrationDataCommanValidation(IAdministratorRepository admRepository)
	{
        RuleFor(x => x.Email)
            .MustAsync(admRepository.IsUniqueEmail)
            .WithMessage("The email must be unique")
            .NotEmpty().WithMessage("This field cannot be empty")
            .EmailAddress().WithMessage("Invalid email format")
            .MaximumLength(256);

        RuleFor(x => x.UserName)
            .MustAsync(admRepository.IsUniqueUserName)
            .WithMessage("The user name must be unique")
            .NotEmpty().WithMessage("This field cannot be empty")
            .MinimumLength(4).MaximumLength(36);

        RuleFor(x => x.BirthDay)
            .NotEmpty().WithMessage("This field cannot be empty")
            .LessThan(DateTime.Now.Date);
    }
}

