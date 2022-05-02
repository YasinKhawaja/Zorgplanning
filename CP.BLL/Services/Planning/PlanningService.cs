using AutoMapper;
using CP.BLL.DTOs;
using CP.DAL.Models;
using CP.DAL.UnitOfWork;
using Microsoft.Extensions.Logging;

namespace CP.BLL.Services.Planning
{
    public class PlanningService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<PlanningService> _logger;

        private IList<Employee> _nurses;
        private IList<CalendarDate> _dates;

        public PlanningService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<PlanningService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _nurses = new List<Employee>();
            _dates = new List<CalendarDate>();
        }

        public async Task<PlanningGetDto> GetMonthlyPlanningAsync(int teamId, int year, int month)
        {
            Team planning = await _unitOfWork.Teams.GetPlanningForTeamForMonthAsync(teamId, year, month);

            List<CalendarDate> dates = await _unitOfWork.CalendarDates.GetAllHolidaysInMonthAsync(year, month);

            PlanningGetDto planningGetDto = new()
            {
                Year = year,
                Month = month,
                Team = _mapper.Map<PlanningTeamGetDto>(planning),
                Holidays = dates.Select(x => x.Date)
            };

            return planningGetDto;
        }

        public async Task<object> GenerateMonthlyPlanning(PlanningPostDto dto)
        {
            await SetupAsync(dto);

            List<Employee> sameNursesWithEarlySchedules =
                PlanningGenerator.GenerateBasicPlanning(this._nurses.ToList(), this._dates.ToList());

            foreach (var nurse in sameNursesWithEarlySchedules)
            {
                IList<Employee> nurseToUp = await _unitOfWork.Employees.FindByAsync(
                    x => x.Id == nurse.Id, asTracking: true, include: "Schedules.CalendarDate");

                List<Schedule> schedules = nurseToUp.First().Schedules.ToList();
                schedules.RemoveAll(x => x.CalendarDate.Date.Year == dto.Year && x.CalendarDate.Date.Month == dto.Month);
                schedules.AddRange(nurse.Schedules);

                nurseToUp.First().Schedules = schedules;
            }

            await _unitOfWork.SaveAsync();
            return "success";
        }

        #region Private Methods
        private static bool IsDateAnAbsence(CalendarDate date, Employee nurse)
        {
            return nurse.Absences.Any(x => x.DateId.Equals(date.DateId));
        }

        private static bool IsDateAnHoliday(CalendarDate date)
        {
            return date.HolidayName is not null;
        }

        private async Task SetupAsync(PlanningPostDto dto)
        {
            this._nurses = await _unitOfWork.Employees.GetAllInTeamAsync(dto.TeamId);
            this._dates = await _unitOfWork.CalendarDates.GetAllInMonthAsync(dto.Year, dto.Month);
        }
        #endregion
    }
}
