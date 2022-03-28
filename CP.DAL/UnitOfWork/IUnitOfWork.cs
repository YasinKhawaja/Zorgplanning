using CP.DAL.Models;
using CP.DAL.Repositories;

namespace CP.DAL.UnitOfWork
{
    /// <summary>
    /// Coordinates the work of multiple repositories by creating a single database context class shared by all of them.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Manages entities of type <seealso cref="Team"/>.
        /// </summary>
        ITeamRepository Teams { get; }

        /// <summary>
        /// Manages entities of type <seealso cref="Employee"/>.
        /// </summary>
        IEmployeeRepository Employees { get; }

        /// <summary>
        /// Manages entities of type <seealso cref="Regime"/>.
        /// </summary>
        IRegimeRepository Regimes { get; }

        /// <summary>
        /// Manages entities of type <seealso cref="Absence"/>.
        /// </summary>
        IAbsenceRepository Absences { get; }

        /// <summary>
        /// Saves all changes made in this context to the database.
        /// </summary>
        Task SaveAsync();
    }
}
