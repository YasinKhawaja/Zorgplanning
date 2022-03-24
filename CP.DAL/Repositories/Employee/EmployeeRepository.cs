using CP.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CP.DAL.Repositories
{
    /// <summary>
    /// Implements <seealso cref="IRegimeRepository"/>.
    /// </summary>
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        /// <summary>
        /// Initializes a new instance of the <seealso cref="RegimeRepository"/> class.
        /// </summary>
        /// <param name="context">The <seealso cref="CarePlannerContext"/> class to inject.</param>
        public EmployeeRepository(CarePlannerContext context)
            : base(context)
        {

        }

        public async Task<IList<Employee>> GetAllInTeamAsync(int teamKey)
        {
            return await base.CarePlannerContext.Employees
                .Where(x => x.TeamId.Equals(teamKey) && x.IsActive.Value)
                .OrderBy(x => x.FirstName)
                .AsNoTracking()
                .ToListAsync();
        }

        public override void Remove(Employee employee)
        {
            employee.IsActive = false;
            base.CarePlannerContext.Employees.Update(employee);
        }
    }
}
