using CP.DAL.Models;
using Microsoft.Extensions.Logging;

namespace CP.BLL.Services.Planning
{
    public class PlanningRules
    {
        const int HOURS_IN_WEEK = 168;
        const int MIN_REST_PER_WEEK = 35;
        const int MIN_REST_BETWEEN_TWO_SHIFTS = 11;

        readonly ILogger<PlanningRules> _logger;

        public PlanningRules(ILogger<PlanningRules> logger)
        {
            _logger = logger;
        }

        public static bool CheckMinimumRestInWeek(List<Schedule> schedules)
        {
            TimeSpan totalRest = new(HOURS_IN_WEEK, 0, 0);

            foreach (var schedule in schedules)
            {
                TimeSpan shiftHours = schedule.Shift.End - schedule.Shift.Start;
                TimeSpan workHours = new(shiftHours.Hours, shiftHours.Minutes, shiftHours.Seconds);
                totalRest -= workHours;
            }

            bool hasEnoughRest = false;

            if (totalRest.TotalHours >= MIN_REST_PER_WEEK)
            {
                hasEnoughRest = true;
            }

            return hasEnoughRest;
        }

        public static bool CheckMinimumRestBetweenShifts(Schedule schedule1, Schedule schedule2)
        {
            var dts1 = GetDateTimeOfSchedule(schedule1);
            var dts2 = GetDateTimeOfSchedule(schedule2);

            DateTime endFirstSchedule = new(dts1.Year, dts1.Month, dts1.Day, dts1.Hour, dts1.Minute, dts1.Second);
            DateTime startSecondSchedule = new(dts2.Year, dts2.Month, dts2.Day, dts2.Hour, dts2.Minute, dts2.Second);

            double restBetweenShifts = startSecondSchedule.Subtract(endFirstSchedule).TotalHours;

            bool hasEnoughRest = false;

            if (restBetweenShifts >= MIN_REST_BETWEEN_TWO_SHIFTS)
            {
                hasEnoughRest = true;
            }

            return hasEnoughRest;
        }

        public static bool CheckIfEmployeeWorksTwoWeekendsInARow()
        {
            return false;
        }

        private static (int Year, int Month, int Day, int Hour, int Minute, int Second)
            GetDateTimeOfSchedule(Schedule schedule)
        {
            return (schedule.CalendarDate.Date.Year,
                schedule.CalendarDate.Date.Month,
                schedule.CalendarDate.Date.Day,
                schedule.Shift.Start.Hours,
                schedule.Shift.Start.Minutes,
                schedule.Shift.Start.Seconds);
        }
    }
}
