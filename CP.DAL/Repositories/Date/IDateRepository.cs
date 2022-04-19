using CP.DAL.Models;

namespace CP.DAL.Repositories
{
    /// <summary>
    /// Manages entities of type <seealso cref="Date"/>.
    /// </summary>
    public interface IDateRepository : IRepository<Date>
    {
        Task<IList<Date>> GetAllInMonthAsync(int year, int month);
    }
}
