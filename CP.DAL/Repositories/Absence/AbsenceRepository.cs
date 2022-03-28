using CP.DAL.Models;

namespace CP.DAL.Repositories
{
    /// <summary>
    /// Implements <seealso cref="IAbsenceRepository"/>.
    /// </summary>
    public class AbsenceRepository : Repository<Absence>, IAbsenceRepository
    {
        /// <summary>
        /// Initializes a new instance of the <seealso cref="AbsenceRepository"/> class.
        /// </summary>
        /// <param name="context">The <seealso cref="CarePlannerContext"/> class to inject.</param>
        public AbsenceRepository(CarePlannerContext context)
            : base(context)
        {

        }
    }
}
