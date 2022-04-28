using CP.DAL.Models;

namespace CP.DAL.Repositories
{
    /// <summary>
    /// Manages entities of type <seealso cref="CalendarDate"/>.
    /// </summary>
    public interface ICalendarDateRepository : IRepository<CalendarDate>
    {
        Task<List<CalendarDate>> GetAllInMonthAsync(int year, int month);
        Task<List<CalendarDate>> GetAllHolidaysAsync();
    }
}
