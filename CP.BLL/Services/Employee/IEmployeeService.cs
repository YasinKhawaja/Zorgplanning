using CP.BLL.DTOs;

namespace CP.BLL.Services
{
    /// <summary>
    /// Manages employees.
    /// </summary>
    public interface IEmployeeService : IService<EmployeeDTO>
    {
        /// <summary>
        /// Gets all active employees in a team.
        /// </summary>
        /// <param name="teamKey">The team key to get the employees from.</param>
        /// <returns></returns>
        Task<IList<EmployeeDTO>> GetAllInTeamAsync(int teamKey);
    }
}
