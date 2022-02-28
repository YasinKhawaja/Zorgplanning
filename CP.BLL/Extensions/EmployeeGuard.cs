using Ardalis.GuardClauses;
using CP.BLL.Exceptions;
using CP.DAL.Models;

namespace CP.BLL.Extensions
{
    /// <summary>
    /// Extends the <seealso cref="IGuardClause"/> interface.
    /// </summary>
    public static class EmployeeGuard
    {
        /// <summary>
        /// Guards if the employee is not found.
        /// </summary>
        /// <param name="guardClause">The interface to extend.</param>
        /// <param name="key">The primary key of the employee.</param>
        /// <param name="employee">The employee itself.</param>
        /// <exception cref="EmployeeNotFoundException">The exception to throw.</exception>
        public static void EmployeeNotFound(this IGuardClause guardClause, int key, Employee employee)
        {
            if (employee is null)
            {
                throw new EmployeeNotFoundException($"EMPLOYEE WITH ID {key} NOT FOUND");
            }
        }
    }
}
