using CP.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CP.DAL.Repositories
{
    /// <summary>
    /// Implements <seealso cref="IDateRepository"/>.
    /// </summary>
    public class DateRepository : Repository<CalendarDate>, IDateRepository
    {
        /// <summary>
        /// Initializes a new instance of the <seealso cref="DateRepository"/> class.
        /// </summary>
        /// <param name="context">The <seealso cref="CarePlannerContext"/> class to inject.</param>
        public DateRepository(CarePlannerContext context)
            : base(context)
        {

        }

        public async Task<IList<CalendarDate>> GetAllInMonthAsync(int year, int month)
        {
            return await base.CarePlannerContext.Dates
                .Where(x => x.Date.Year.Equals(year) && x.Date.Month.Equals(month))
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
