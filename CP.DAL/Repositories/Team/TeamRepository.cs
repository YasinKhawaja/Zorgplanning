using CP.DAL.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Team> GetPlanningForTeamForMonthAsync(int teamId, int year, int month)
        {
            return await base.CarePlannerContext.Teams
                .AsNoTracking()
                .Where(t => t.Id == teamId)
                .Include(t => t.Employees
                        .OrderBy(e => e.FirstName))
                    .ThenInclude(e => e.Regime)
                .Include(t => t.Employees)
                    .ThenInclude(e => e.Schedules
                            .Where(s => s.CalendarDate.Date.Year == year && s.CalendarDate.Date.Month == month)
                            .OrderBy(s => s.CalendarDate.Date))
                        .ThenInclude(s => s.CalendarDate)
                 .Include(t => t.Employees)
                    .ThenInclude(e => e.Schedules)
                        .ThenInclude(s => s.Shift)
                .Include(t => t.Employees)
                    .ThenInclude(e => e.Absences
                            .Where(a => a.CalendarDate.Date.Year == year && a.CalendarDate.Date.Month == month))
                        .ThenInclude(a => a.CalendarDate)
                .FirstOrDefaultAsync();
        }
    }
}
