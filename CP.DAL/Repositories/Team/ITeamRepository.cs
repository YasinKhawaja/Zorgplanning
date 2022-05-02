using CP.DAL.Models;

namespace CP.DAL.Repositories
{
    /// <summary>
    /// Manages entities of type <seealso cref="Team"/>.
    /// </summary>
    public interface ITeamRepository : IRepository<Team>
    {
        Task<Team> GetPlanningForTeamForMonthAsync(int teamId, int year, int month);
    }
}
