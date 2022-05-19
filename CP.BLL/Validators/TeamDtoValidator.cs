using CP.BLL.DTOs;
using CP.DAL.UnitOfWork;
using FluentValidation;

namespace CP.BLL.Validators
{
    public class TeamDtoValidator : AbstractValidator<TeamDTO>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeamDtoValidator(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;

            base.RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("'Naam' mag niet leeg zijn.")
                .Length(2, 100)
                .WithMessage("'Naam' moet tussen de 2 en 100 tekens lang zijn.");

            base.When(x => x.Name.Length > 1, () =>
            {
                base.RuleFor(x => x.Name)
                    .Custom((name, context) =>
                    {
                        var teamFound = _unitOfWork.Teams.FindByAsync(x => x.Name.Equals(name)).Result.FirstOrDefault();
                        if (teamFound is not null && teamFound.Name.Equals(name))
                        {
                            context.AddFailure("'Naam' bestaat al.");
                        }
                    });
            });
        }
    }
}
