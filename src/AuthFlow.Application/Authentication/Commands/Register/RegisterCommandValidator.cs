using FluentValidation;

namespace AuthFlow.Application.Authentication.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(100);

        RuleFor(x => x.Password)
            .NotEmpty()
            .Equal(x => x.PasswordConfirmation)
            .MaximumLength(255);

        RuleFor(x => x.PasswordConfirmation)
            .NotEmpty()
            .MaximumLength(255);
    }
}
