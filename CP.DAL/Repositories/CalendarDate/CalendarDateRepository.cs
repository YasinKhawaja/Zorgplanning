using CP.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CP.DAL.Repositories
{
    /// <summary>
    /// Implements <seealso cref="ICalendarDateRepository"/>.
    /// </summary>
    public class CalendarDateRepository : Repository<CalendarDate>, ICalendarDateRepository
    {
        /// <summary>
        /// Initializes a new instance of the <seealso cref="CalendarDateRepository"/> class.
        /// </summary>
        /// <param name="context">The <seealso cref="CarePlannerContext"/> class to inject.</param>
        public CalendarDateRepository(CarePlannerContext context)
            : base(context)
        {

        }

        public async Task<List<CalendarDate>> GetAllHolidaysInMonthAsync(int year, int month)
        {
            return await base.CarePlannerContext.CalendarDates
                .AsNoTracking()
                .Where(x => x.Date.Year == year && x.Date.Month == month && !string.IsNullOrEmpty(x.HolidayName))
                .ToListAsync();
        }

        public async Task<List<CalendarDate>> GetAllHolidaysAsync()
        {
            return await base.CarePlannerContext.CalendarDates
                .AsNoTracking()
                .Where(x => !string.IsNullOrEmpty(x.HolidayName))
                .ToListAsync();
        }

        public async Task<List<CalendarDate>> GetAllInMonthAsync(int year, int month)
        {
            return await base.CarePlannerContext.CalendarDates
                .AsNoTracking()
                .Where(x => x.Date.Year == year && x.Date.Month == month)
                .Include(x => x.Schedules)
                    .ThenInclude(x => x.Shift)
                .ToListAsync();
        }
    }
}
