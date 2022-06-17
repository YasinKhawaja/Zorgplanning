using AutoMapper;
using CP.BLL.DTOs;
using CP.DAL.Models;

namespace CP.BLL.Mappings.Resolvers
{
    public class TeamHasChildrenResolver : IValueResolver<Team, TeamDTO, bool>
    {
        public bool Resolve(Team source, TeamDTO destination, bool destMember, ResolutionContext context)
        {
            return source.Employees is not null && source.Employees.Any();
        }
    }
}
