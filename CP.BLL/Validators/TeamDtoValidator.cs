using CP.BLL.DTOs;
using FluentValidation;

namespace CP.BLL.Validators
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
