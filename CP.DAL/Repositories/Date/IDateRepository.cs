using CP.DAL.Models;

namespace CP.DAL.Repositories
{
    /// <summary>
    /// Manages entities of type <seealso cref="CalendarDate"/>.
    /// </summary>
    public interface IDateRepository : IRepository<CalendarDate>
    {
        Task<IList<CalendarDate>> GetAllInMonthAsync(int year, int month);
    }
}
