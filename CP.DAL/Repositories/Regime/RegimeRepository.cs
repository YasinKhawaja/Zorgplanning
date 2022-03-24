using CP.DAL.Models;

namespace CP.DAL.Repositories
{
    /// <summary>
    /// Implements <seealso cref="IRegimeRepository"/>.
    /// </summary>
    public class RegimeRepository : Repository<Regime>, IRegimeRepository
    {
        /// <summary>
        /// Initializes a new instance of the <seealso cref="RegimeRepository"/> class.
        /// </summary>
        /// <param name="context">The <seealso cref="CarePlannerContext"/> class to inject.</param>
        public RegimeRepository(CarePlannerContext context)
            : base(context)
        {

        }
    }
}
