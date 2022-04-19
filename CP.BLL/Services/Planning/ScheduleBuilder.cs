using CP.DAL.Models;

namespace CP.BLL.Services.Planning
{
    public class ScheduleBuilder : IScheduleBuilder
    {
        private Schedule _schedule = new();

        public ScheduleBuilder()
        {
            this.Reset();
        }

        public ScheduleBuilder ForEmployee(int employeeId)
        {
            this._schedule.EmployeeId = employeeId;
            return this;
        }

        public ScheduleBuilder WithShift(int shiftId)
        {
            this._schedule.ShiftId = shiftId;
            return this;
        }

        public ScheduleBuilder OnDay(DateTime day)
        {
            this._schedule.DateId = day;
            return this;
        }

        public Schedule Build()
        {
            Schedule schedule = this._schedule;
            this.Reset();
            return schedule;
        }

        private void Reset()
        {
            this._schedule = new Schedule();
        }
    }
}
