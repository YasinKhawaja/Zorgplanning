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
                .Where(t => t.Id == teamId)
                .Include(t => t.Employees)
                    .ThenInclude(e => e.Regime)
                .Include(t => t.Employees)
                    .ThenInclude(e => e.Schedules
                            .Where(s => s.CalendarDate.Date.Year == year && s.CalendarDate.Date.Month == month))
                        .ThenInclude(s => s.CalendarDate)
                 .Include(t => t.Employees)
                    .ThenInclude(e => e.Schedules
                            .Where(s => s.CalendarDate.Date.Year == year && s.CalendarDate.Date.Month == month))
                        .ThenInclude(s => s.Shift)
                .Include(t => t.Employees)
                    .ThenInclude(e => e.Absences)
                        .ThenInclude(a => a.CalendarDate)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
