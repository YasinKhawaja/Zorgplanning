using Ardalis.GuardClauses;
using CP.BLL.Exceptions;
using CP.DAL.Models;

namespace CP.BLL.Extensions
{
    public static class RegimeGuard
    {
        public static void IsRegimeFound(this IGuardClause guardClause, Regime regime)
        {
            if (regime is null)
            {
                throw new GuardClauseException("The regime could not be found.");
            }
        }
    }
}
