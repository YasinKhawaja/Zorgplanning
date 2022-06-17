using Ardalis.GuardClauses;
using CP.BLL.Exceptions;
using CP.DAL.Models;

namespace CP.BLL.Extensions
{
    /// <summary>
    /// Extends the <seealso cref="IGuardClause"/> interface.
    /// </summary>
    public static class GuardClause
    {
        public static void IsTeamFound(this IGuardClause guardClause, Team team)
        {
            if (team is null)
            {
                throw new GuardClauseException("The team could not be found.");
            }
        }

        public static void HasTeamEmployees(this IGuardClause guardClause, Team team)
        {
            bool teamHasEmployees = team.Employees.Any();
            if (teamHasEmployees)
            {
                throw new GuardClauseException("The team could not be deleted.");
            }
        }

        /// <summary>
        /// Guards if the employee is not found.
        /// </summary>
        /// <param name="guardClause">The interface to extend.</param>
        /// <param name="key">The primary key of the employee.</param>
        /// <param name="employee">The employee itself.</param>
        /// <exception cref="GuardClauseException">The exception to throw.</exception>
        public static void EmployeeNotFound(this IGuardClause guardClause, Employee employee)
        {
            if (employee is null)
            {
                throw new GuardClauseException("The employee could not be found.");
            }
        }

        public static void RegimeNotFound(this IGuardClause guardClause, Regime regime)
        {
            if (regime is null)
            {
                throw new GuardClauseException("The regime could not be found.");
            }
        }

        public static void AbsenceNotFound(this IGuardClause guardClause, Absence absence)
        {
            if (absence is null)
            {
                throw new GuardClauseException("The absence could not be found.");
            }
        }
    }
}
