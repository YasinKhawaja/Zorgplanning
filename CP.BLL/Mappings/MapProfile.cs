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
                .ForMember(x => x.HasChildren, o => o.MapFrom<TeamHasChildrenResolver>())
                .ReverseMap();

            base.CreateMap<Employee, EmployeeDTO>().ReverseMap();
            base.CreateMap<Regime, RegimeDTO>().ReverseMap();

            base.CreateMap<Absence, AbsenceDTO>()
                .ForMember(x => x.Day, o => o.MapFrom(x => x.DateId))
                .ReverseMap();
        }
    }
}
