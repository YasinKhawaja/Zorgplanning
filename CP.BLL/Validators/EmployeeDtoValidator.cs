using CP.BLL.DTOs;
using FluentValidation;

namespace CP.BLL.Validators
{
    public class EmployeeDtoValidator : AbstractValidator<EmployeeDTO>
    {
        public EmployeeDtoValidator()
        {
            base.RuleFor(x => x.Id)
                .NotNull();

            base.RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("'Voornaam' mag niet leeg zijn.")
                .MaximumLength(100)
                .WithMessage("De lengte van 'Voornaam' moet 100 tekens of minder zijn.");

            base.RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("'Achternaam' mag niet leeg zijn.")
                .MaximumLength(100)
                .WithMessage("De lengte van 'Achternaam' moet 100 tekens of minder zijn.");

            base.RuleFor(x => x.TeamId)
                .NotEmpty();

            base.RuleFor(x => x.RegimeId)
                .NotEmpty()
                .WithMessage("'Regime' mag niet leeg zijn.");
        }
    }
}
