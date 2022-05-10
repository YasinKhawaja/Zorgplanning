using AutoMapper;
using CP.BLL.DTOs;
using CP.DAL.Models;
using CP.DAL.UnitOfWork;

namespace CP.BLL.Services.Planning
{
    public class PlanningService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PlanningService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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

        public async Task GenerateMonthlyPlanning(PlanningPostDto dto)
        {
            List<Employee> nurses = await _unitOfWork.Employees.GetAllInTeamAsync(dto.TeamId);
            List<CalendarDate> dates = await _unitOfWork.CalendarDates.GetAllInMonthAsync(dto.Year, dto.Month);

            PlanningGenerator generator = new(nurses, dates);
            List<Employee> nursesWithNewSchedules = generator.GenerateMonthlyPlanning(nurses, dates);

            foreach (var nurse in nursesWithNewSchedules)
            {
                await SaveNurseSchedulesForMonthAsync(nurse, dto.Year, dto.Month);
            }
        }

        private async Task SaveNurseSchedulesForMonthAsync(Employee nurse, int year, int month)
        {
            IList<Schedule> oldSchedules = await _unitOfWork.Schedules.FindByAsync(
                x => x.EmployeeId == nurse.Id && x.CalendarDate.Date.Year == year && x.CalendarDate.Date.Month == month);

            foreach (var schedule in oldSchedules)
            {
                _unitOfWork.Schedules.Remove(schedule);
                await _unitOfWork.SaveAsync();
            }

            foreach (var schedule in nurse.Schedules)
            {
                await _unitOfWork.Schedules.AddAsync(new Schedule()
                {
                    EmployeeId = schedule.EmployeeId,
                    DateId = schedule.DateId,
                    ShiftId = schedule.ShiftId
                });
            }

            await _unitOfWork.SaveAsync();
        }
    }
}
