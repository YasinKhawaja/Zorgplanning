using CP.DAL.Models;

namespace CP.BLL.Services.Planning
{
    public class PlanningGenerator
    {
        public static Employee GenerateBasicPlanning(Employee nurse, List<CalendarDate> dates)
        {
            Shift noneShift = nurse.Regime.Shifts.ToList().First(s => s.Name.ToLower().Trim() == "geen");

            List<Schedule> noneSchedules = new();

            foreach (var date in dates)
            {
                Schedule schedule = new()
                {
                    EmployeeId = nurse.Id,
                    DateId = date.DateId,
                    ShiftId = noneShift.Id
                };

                noneSchedules.Add(schedule);
            }

            nurse.Schedules = noneSchedules;

            return nurse;
        }
    }
}
