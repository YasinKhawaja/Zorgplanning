using CP.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CP.DAL.Repositories
{
    /// <summary>
    /// Implements <seealso cref="IDateRepository"/>.
    /// </summary>
    public class DateRepository : Repository<Date>, IDateRepository
    {
        /// <summary>
        /// Initializes a new instance of the <seealso cref="DateRepository"/> class.
        /// </summary>
        /// <param name="context">The <seealso cref="CarePlannerContext"/> class to inject.</param>
        public DateRepository(CarePlannerContext context)
            : base(context)
        {

        }

        public async Task<IList<Date>> GetAllInMonthAsync(int year, int month)
        {
            return await base.CarePlannerContext.Dates
                .Where(x => x.DateId.Year.Equals(year) && x.DateId.Month.Equals(month))
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
