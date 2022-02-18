using CP.BLL.Services;
using FluentValidation;

namespace CP.BLL.FluentValidation.Validators
{
    public class TeamDtoValidator : AbstractValidator<TeamDTO>
    {
        public TeamDtoValidator()
        {
            base.RuleFor(t => t.Id)
                .NotNull();

            base.RuleFor(t => t.Name)
                .NotNull()
                .NotEmpty()
                .Length(2, 100);
        }
    }
}
