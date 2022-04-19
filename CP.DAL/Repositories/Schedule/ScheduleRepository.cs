using CP.DAL.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CP.DAL.Repositories
{
    /// <summary>
    /// Implements <seealso cref="IScheduleRepository"/>.
    /// </summary>
    public class ScheduleRepository : Repository<Schedule>, IScheduleRepository
    {
        /// <summary>
        /// Initializes a new instance of the <seealso cref="ScheduleRepository"/> class.
        /// </summary>
        /// <param name="context">The <seealso cref="CarePlannerContext"/> class to inject.</param>
        public ScheduleRepository(CarePlannerContext context)
            : base(context)
        {

        }
    }
}
