using CP.BLL.DTOs;
using CP.DAL.Models;
using FluentValidation;

namespace CP.BLL.Validators
{
    public class AbsenceDtoValidator : AbstractValidator<AbsenceDTO>
    {
        public AbsenceDtoValidator()
        {
            base.RuleFor(x => x.Type)
                .NotEmpty();

            base.When(x => x.Type.Length > 0, () =>
            {
                base.RuleFor(x => x.Type)
                    .IsEnumName(typeof(AbsenceType));
            });
        }
    }
}
