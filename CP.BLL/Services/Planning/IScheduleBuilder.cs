using CP.DAL.Models;

namespace CP.BLL.Services.Planning
{
    public interface IScheduleBuilder : IBuilder<Schedule>
    {
        ScheduleBuilder ForEmployee(int employeeId);
        ScheduleBuilder WithShift(int shiftId);
        ScheduleBuilder OnDay(DateTime day);
    }
}
