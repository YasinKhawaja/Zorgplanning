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

        public async Task<Employee> FindEmployeeWithSchedulesInMonth(
            int employeeId, int year, int month, bool asTracking = false)
        {
            IQueryable<Employee> query;
            if (asTracking)
            {
                query = base.CarePlannerContext.Employees;
            }
            else
            {
                query = base.CarePlannerContext.Employees.AsNoTracking();
            }
            query = query
                .Where(e => e.Id == employeeId)
                .Include(e => e.Schedules
                        .Where(s => s.CalendarDate.Date.Year == year && s.CalendarDate.Date.Month == month));
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<Employee>> GetAllInTeamAsync(int teamId)
        {
            return await base.CarePlannerContext.Employees
                .AsNoTracking()
                .Where(e => e.TeamId == teamId)
                .Include(e => e.Regime)
                    .ThenInclude(r => r.Shifts)
                .Include(e => e.Absences)
                    .ThenInclude(a => a.CalendarDate)
                .Include(e => e.Schedules)
                .OrderBy(e => e.FirstName)
                .ToListAsync();
        }
    }
}
