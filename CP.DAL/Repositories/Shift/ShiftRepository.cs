using CP.DAL.Models;

namespace CP.DAL.Repositories
{
    /// <summary>
    /// Implements <seealso cref="IShiftRepository"/>.
    /// </summary>
    public class ShiftRepository : Repository<Shift>, IShiftRepository
    {
        /// <summary>
        /// Initializes a new instance of the <seealso cref="ShiftRepository"/> class.
        /// </summary>
        /// <param name="context">The <seealso cref="CarePlannerContext"/> class to inject.</param>
        public ShiftRepository(CarePlannerContext context)
            : base(context)
        {

        }
    }
}
