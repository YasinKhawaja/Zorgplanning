using AutoMapper;
using ClosedXML.Excel;
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
                schedule = planner.BuildEarlySchedule(nurse.Id, nurseShifts[0].Id, date.Date);
                schedules.Add(schedule);
            }
            nurse.Schedules = schedules;
            await _unitOfWork.SaveAsync();
            return "success";
        }

        public XLWorkbook BuildExcelFile(int teamId, int year, int month)
        {
            var wb = new XLWorkbook();
            var ws = wb.AddWorksheet("Planning");
            ws.Cell("B2").Value = "Contacts";
            ws.Cell("B3").Value = "FName";
            ws.Cell("B4").Value = "John";
            ws.Cell("B5").Value = "Hank";
            ws.Cell("B6").Value = "Dagny";
            ws.Cell("C3").Value = "LName";
            ws.Cell("C4").Value = "Galt";
            ws.Cell("C5").Value = "Rearden";
            ws.Cell("C6").Value = "Taggart";
            ws.Cell("D3").Value = "Outcast";
            ws.Cell("D4").Value = true;
            ws.Cell("D5").Value = false;
            ws.Cell("D6").Value = false;
            ws.Cell("E3").Value = "DOB";
            ws.Cell("E4").Value = new DateTime(1919, 1, 21);
            ws.Cell("E5").Value = new DateTime(1907, 3, 4);
            ws.Cell("E6").Value = new DateTime(1921, 12, 15);
            ws.Cell("F3").Value = "Income";
            ws.Cell("F4").Value = 2000;
            ws.Cell("F5").Value = 40000;
            ws.Cell("F6").Value = 10000;
            var rngTable = ws.Range("B2:F6");
            var rngDates = rngTable.Range("E4:E6");
            var rngNumbers = rngTable.Range("F4:F6");
            rngDates.Style.NumberFormat.NumberFormatId = 15;
            rngNumbers.Style.NumberFormat.Format = "$ #,##0";
            var rngHeaders = rngTable.Range("B3:F3");
            rngHeaders.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            rngHeaders.Style.Font.Bold = true;
            rngHeaders.Style.Fill.BackgroundColor = XLColor.Aqua;
            rngTable.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            rngTable.Cell(1, 1).Style.Font.Bold = true;
            rngTable.Cell(1, 1).Style.Fill.BackgroundColor = XLColor.CornflowerBlue;
            rngTable.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            rngTable.Row(1).Merge();
            rngTable.Style.Border.OutsideBorder = XLBorderStyleValues.Thick;
            ws.Columns(2, 6).AdjustToContents();
            return wb;
        }

        #region Private Methods
        private static bool IsDateAnAbsence(CalendarDate date, Employee nurse)
        {
            return nurse.Absences.Any(x => x.DateId.Equals(date.DateId));
        }

        private static bool IsDateAnHoliday(CalendarDate date)
        {
            return date.IsHoliday;
        }
        #endregion
    }
}
