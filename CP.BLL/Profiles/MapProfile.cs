using AutoMapper;
using CP.BLL.DTOs;
using CP.DAL.Models;

namespace CP.BLL.Profiles
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
            base.CreateMap<Team, TeamDTO>().ReverseMap();
            base.CreateMap<Employee, EmployeeDTO>().ReverseMap();
        }
    }
}
