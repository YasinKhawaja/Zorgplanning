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
        private IList<Date> _dates;

        public PlanningService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<PlanningService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _nurses = new List<Employee>();
            _dates = new List<Date>();
        }

        public async Task<PlanningDTO> GetMonthlyPlanningAsync(int teamID, int year, int month)
        {
            PlanningDTO planningDTO = new();
            planningDTO.TeamId = teamID;
            planningDTO.Year = year;
            planningDTO.Month = month;
            return planningDTO;
        }

        public async Task SetupAsync(PlanningCreateDTO dto)
        {
            this._nurses = await _unitOfWork.Employees.GetAllInTeamAsync(dto.TeamId);
            this._dates = await _unitOfWork.Dates.GetAllInMonthAsync(dto.Year, dto.Month);
        }

        public async Task<object> GenerateMonthlyPlanning(PlanningCreateDTO dto)
        {
            await SetupAsync(dto);
            PlanningDirector planner = new();
            ScheduleBuilder builder = new();
            planner.ScheduleBuilder = builder;
            Employee nurse = _nurses.FirstOrDefault();
            IList<Shift> nurseShifts = await _unitOfWork.Shifts.FindByAsync(x => x.RegimeId.Equals(nurse.RegimeId));
            List<Schedule> schedules = new();
            foreach (var date in this._dates)
            {
                Schedule schedule = new();
                // Check if the date is available to schedule.
                if (IsDateAnAbsence(date, nurse) || IsDateAnHoliday(date))
                {
                    schedule = new Schedule() { EmployeeId = nurse.Id, ShiftId = nurseShifts[3].Id, DateId = date.DateId };
                }
                schedule = planner.BuildEarlySchedule(nurse.Id, nurseShifts[0].Id, date.DateId);
                schedules.Add(schedule);
            }
            nurse.Schedules = schedules;
            await _unitOfWork.SaveAsync();
            return "success";
        }

        #region Private Methods
        private static bool IsDateAnAbsence(Date date, Employee nurse)
        {
            return nurse.Absences.Any(x => x.DateId.Equals(date.DateId));
        }

        private static bool IsDateAnHoliday(Date date)
        {
            return date.IsHoliday;
        }
        #endregion
    }
}
