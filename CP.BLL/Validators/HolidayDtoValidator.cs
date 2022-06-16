using CP.BLL.DTOs;
using FluentValidation;

namespace CP.BLL.Validators
{
    public class HolidayDtoValidator : AbstractValidator<HolidayDTO>
    {
        public HolidayDtoValidator()
        {
            base.RuleFor(dto => dto.Date)
                .NotNull()
                .WithMessage("'Datum' mag niet leeg zijn.");

            base.RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("'Naam' mag niet leeg zijn.");
        }
    }
}
