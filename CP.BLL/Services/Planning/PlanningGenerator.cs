using CP.DAL.Models;

namespace CP.BLL.Services.Planning
{
    public class PlanningGenerator
    {
        public static List<Employee> GenerateBasicPlanning(List<Employee> nurses, List<CalendarDate> dates)
        {
            foreach (var nurse in nurses)
            {
                Shift morningShift = nurse.Regime.Shifts.ToList().First(s => s.Name.ToLower().Trim() == "vroeg");
                List<Schedule> schedulesNew = new();
                foreach (var date in dates)
                {
                    Schedule schedule = new()
                    {
                        EmployeeId = nurse.Id,
                        DateId = date.DateId,
                        ShiftId = morningShift.Id
                    };
                    schedulesNew.Add(schedule);
                }
                nurse.Schedules = schedulesNew;
            }
            return nurses;
        }
    }
}
