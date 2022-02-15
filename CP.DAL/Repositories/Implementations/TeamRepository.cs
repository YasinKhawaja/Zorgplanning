using CP.DAL.Models;
using CP.DAL.Repositories.Interfaces;

namespace CP.DAL.Repositories.Implementations
{
    /// <summary>
    /// Inherits from the <seealso cref="RepositoryBase{T}"/> class and 
    /// implements the <seealso cref="ITeamRepository"/> interface.
    /// </summary>
    public class TeamRepository : RepositoryBase<Team>, ITeamRepository
    {
        public TeamRepository(CarePlannerContext context)
            : base(context)
        {

        }
    }
}
