﻿using AutoMapper;
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

            base.CreateMap<Employee, EmployeeDTO>()
                .ForMember(x => x.RegimeName, x => x.MapFrom(y => y.Regime.Name));

            base.CreateMap<EmployeeDTO, Employee>();

            base.CreateMap<Regime, RegimeDTO>().ReverseMap();

            base.CreateMap<Absence, AbsenceDTO>()
                .ForMember(x => x.EmployeeId, x => x.MapFrom(x => x.EmployeeId))
                .ForMember(x => x.Day, x => x.MapFrom(x => x.DateId))
                .ForMember(x => x.Type, x => x.MapFrom(x => x.Type.ToString()));

            base.CreateMap<AbsenceDTO, Absence>()
                .ForMember(x => x.EmployeeId, x => x.MapFrom(x => x.EmployeeId))
                .ForMember(x => x.DateId, x => x.MapFrom(x => x.Day))
                .ForMember(x => x.Type, x => x.MapFrom<AbsenceTypeStringToEnumResolver>());

            base.CreateMap<CalendarDate, HolidayDTO>()
                .ForMember(x => x.Date, x => x.MapFrom(x => x.Date))
                .ForMember(x => x.Name, x => x.MapFrom(x => x.HolidayName));

            // PLANNING
            base.CreateMap<Team, PlanningTeamGetDto>();
            base.CreateMap<Employee, PlanningEmployeeGetDto>();
            base.CreateMap<Regime, PlanningRegimeGetDto>();
            base.CreateMap<Shift, PlanningShiftGetDto>();

            base.CreateMap<Absence, PlanningAbsenceGetDto>()
                .ForMember(x => x.Date, x => x.MapFrom(x => x.CalendarDate.Date))
                .ForMember(x => x.Type, x => x.MapFrom(x => x.Type.ToString()));

            base.CreateMap<Schedule, PlanningScheduleGetDto>()
                .ForMember(x => x.Date, x => x.MapFrom(x => x.CalendarDate.Date));
        }
    }
}
