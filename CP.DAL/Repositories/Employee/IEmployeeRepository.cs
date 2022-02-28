using CP.DAL.Models;

namespace CP.DAL.Repositories
{
    /// <summary>
    /// Manages entities of type <seealso cref="Employee"/>.
    /// </summary>
    public interface IEmployeeRepository : IRepository<Employee>
    {
        /// <summary>
        /// Gets all active employees in a team.
        /// </summary>
        /// <param name="teamKey">The team key to get the employees from.</param>
        /// <returns></returns>
        Task<IList<Employee>> GetAllInTeamAsync(int teamKey);
    }
}
