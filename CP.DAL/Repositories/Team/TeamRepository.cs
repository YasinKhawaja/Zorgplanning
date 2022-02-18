using CP.DAL.Models;

namespace CP.DAL.Repositories
{
    /// <summary>
    /// Implements <seealso cref="ITeamRepository"/>.
    /// </summary>
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TeamRepository(CarePlannerContext context)
            : base(context)
        {

        }
    }
}
