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
                .Length(2, 100);

            base.When(x => x.Name.Length > 1, () =>
            {
                base.RuleFor(x => x.Name)
                    .Custom((name, context) =>
                    {
                        var teamFound = _unitOfWork.Teams.FindByAsync(x => x.Name.Equals(name)).Result.FirstOrDefault();
                        if (teamFound is not null && teamFound.Name.Equals(name))
                        {
                            context.AddFailure("'Name' already exists.");
                        }
                    });
            });
        }
    }
}
