using CP.DAL.Models;

namespace CP.BLL.Services.Planning
{
    public class PlanningRules
    {
        const int HOURS_IN_DAY = 24;
        const int HOURS_IN_WEEK = 168;
        const int MIN_REST_PER_WEEK = 35;
        const int MIN_REST_BETWEEN_TWO_SHIFTS = 11;

        public static bool CheckGuaranteedOccupation(CalendarDate day)
        {
            //for (int i = 0; i < HOURS_IN_DAY; i++)
            //{
            //    DateTime startHour = new(day.Date.Year, day.Date.Month, day.Date.Day, i, 0, 0);
            //    DateTime startNextHour = startHour.AddHours(1);

            //    if (day.Shifts[i] != null)
            //    {
            //        if (!day.Shifts[i].Guaranteed)
            //        {
            //            return false;
            //        }
            //    }
            //}

            return true;
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

        public static bool CheckIfEmployeeWorksTwoWeekendsInARow(List<Schedule> schedules)
        {
            bool worksTwoWeekendsInARow = false;

            // for (int i = 0; i < schedules.Count - 1; i += 2)
            // {
            //     List<Schedule> shifts1 = schedules.Skip(i).Take(2).ToList(); // First weekend
            //     List<Schedule> shifts2 = schedules.Skip(i += 2).Take(2).ToList(); // Second weekend

            //     if (shifts1[0].Shift.Start.DayOfWeek == DayOfWeek.Saturday && shifts1[1].Shift.Start.DayOfWeek == DayOfWeek.Sunday &&
            //         shifts2[0].Shift.Start.DayOfWeek == DayOfWeek.Sunday && shifts2[1].Shift.Start.DayOfWeek == DayOfWeek.Monday)
            //     {
            //         worksTwoWeekendsInARow = true;
            //     }
            // }

            return worksTwoWeekendsInARow;
        }

        public static bool CheckDistributionOfLateShifts()
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
