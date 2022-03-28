using CP.BLL.DTOs;
using FluentValidation;

namespace CP.BLL.Validators
{
    public class AbsenceDtoValidator : AbstractValidator<AbsenceDTO>
    {
        public AbsenceDtoValidator()
        {
            base.RuleFor(x => x.Day)
                .NotEmpty();

            base.RuleFor(x => x.Type)
                //.NotEmpty()
                .IsInEnum();
        }
    }
}
