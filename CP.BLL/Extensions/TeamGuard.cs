using Ardalis.GuardClauses;
using CP.BLL.Exceptions;
using CP.DAL.Models;

namespace CP.BLL.Extensions
{
    public static class TeamGuard
    {
        public static void IsTeamFound(this IGuardClause guardClause, Team team)
        {
            if (team is null)
            {
                throw new GuardClauseException("TEAM NOT FOUND");
            }
        }
    }
}
