using AutoMapper;
using CP.BLL.DTOs;
using CP.BLL.Mappings.Resolvers;
using CP.DAL.Models;

namespace CP.BLL.Mappings
{
    /// <summary>
    /// Configures mapping classes.
    /// </summary>
    public class MapProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <seealso cref="MapProfile"/> class.
        /// </summary>
        public MapProfile()
        {
            base.CreateMap<Team, TeamDTO>()
                .ForMember(x => x.Id, o => o.MapFrom(x => x.Id))
                .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
                .ForMember(x => x.HasChildren, o => o.MapFrom<TeamHasChildrenResolver>());
            
            base.CreateMap<TeamDTO, Team>();
            base.CreateMap<Employee, EmployeeDTO>().ReverseMap();
            base.CreateMap<Regime, RegimeDTO>().ReverseMap();
        }
    }
}
