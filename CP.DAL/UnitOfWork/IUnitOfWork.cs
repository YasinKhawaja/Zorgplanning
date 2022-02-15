using CP.DAL.Repositories.Interfaces;

namespace CP.DAL.UnitOfWork
{
    /// <summary>
    /// Coordinates the work of multiple repositories by creating a single database context class shared by all of them.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        ITeamRepository Teams { get; }

        /// <summary>
        /// Saves all changes made in this context to the database.
        /// </summary>
        void Save();
    }
}
