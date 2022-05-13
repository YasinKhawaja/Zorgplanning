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
                .MaximumLength(100);

            base.RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(100);

            base.RuleFor(x => x.TeamId)
                .NotEmpty();

            base.RuleFor(x => x.RegimeId)
                .NotEmpty()
                .WithMessage("'Regime' must not be empty.");
        }
    }
}
