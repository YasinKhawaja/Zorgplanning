using CP.BLL.Services.Planning;
using CP.DAL.Models;

namespace CP.BLL.Services
{
    public class PlanningDirector
    {
        public IScheduleBuilder ScheduleBuilder { private get; set; }

        public Schedule BuildEarlySchedule(int employeeId, int shiftId, DateTime day)
        {
            return this.ScheduleBuilder.ForEmployee(employeeId).WithShift(shiftId).OnDay(day).Build();
        }

        public void BuildLateScheduleFor()
        {
            throw new NotImplementedException();
        }

        public void BuildNightScheduleFor()
        {
            throw new NotImplementedException();
        }
    }
}
