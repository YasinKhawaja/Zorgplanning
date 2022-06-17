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
        /// <param name="teamId">The team key to get the employees from.</param>
        /// <returns></returns>
        Task<List<Employee>> GetAllInTeamAsync(int teamId);
        Task<Employee> FindEmployeeWithSchedulesInMonth(int employeeId, int year, int month, bool asTracking = false);
    }
}
