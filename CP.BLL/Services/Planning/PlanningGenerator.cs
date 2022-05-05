using CP.DAL.Models;

namespace CP.BLL.Services.Planning
{
    public class PlanningGenerator
    {
        const string NONE = "geen";
        const string EARLY = "vroeg";
        const string LATE = "laat";
        const string NIGHT = "nacht";

        public static List<Employee> GenerateMonthlyPlanning(List<Employee> nurses, List<CalendarDate> month)
        {
            ResetAllSchedules(ref nurses, month);

            foreach (var day in month)
            {
                // Because all the nurses have "none" ("geen") schedules assigned at first,
                // we don't need to do anything if the day is a holiday and just skip it.
                if (IsHoliday(day))
                {
                    continue;
                }

                Shuffle(ref nurses);

                day.Schedules = new List<Schedule>();
                List<Schedule> schedulesOnDay = day.Schedules.ToList();

                List<Employee> remainingNursesForEarly = nurses.ToList();

                List<Employee> nursesLate = remainingNursesForEarly.ToList();

                foreach (var nurse in remainingNursesForEarly)
                {
                    if (IsAbsent(nurse, day))
                    {
                        Schedule noneSchedule = MakeSchedule(nurse, day, GetShift(nurse, NONE));
                        schedulesOnDay.Add(noneSchedule);
                        nursesLate.Remove(nurse);
                        continue;
                    }

                    if (nurse.IsFixedNight)
                    {
                        continue;
                    }

                    Schedule schedule = new();

                    if (schedulesOnDay.FindAll(s => s.Shift.Name.ToLower() == EARLY).Count < 2)
                    {
                        schedule = MakeSchedule(nurse, day, GetShift(nurse, EARLY));
                    }
                    //else if (schedulesOnDay.FindAll(s => s.Shift.Name == "Laat").Count < 2)
                    //{
                    //    schedule = MakeSchedule(nurse, day, GetShift(nurse, "laat"));
                    //}
                    //else if (schedulesOnDay.FindAll(s => s.Shift.Name == "Nacht").Count < 1)
                    //{
                    //    schedule = MakeSchedule(nurse, day, GetShift(nurse, "nacht"));
                    //}
                    else { continue; }

                    nurse.Schedules.ToList().Find(s => s.DateId == schedule.DateId).ShiftId = schedule.ShiftId;
                    schedulesOnDay.Add(schedule);
                    nursesLate.Remove(nurse);
                }

                List<Employee> remainingNursesForLate = nursesLate.ToList();

                //while (remainingNursesForEarly.Count > 0)
                //{

                //}
            }

            return nurses;
        }

        private static bool CheckMinimumOccupancy(CalendarDate day)
        {
            return day.Schedules.ToList().FindAll(s => s.Shift.Name == "vroeg").Count() < 2;
        }

        private static Schedule MakeSchedule(Employee nurse, CalendarDate day, Shift shift)
        {
            return new Schedule()
            {
                EmployeeId = nurse.Id,
                Employee = nurse,
                DateId = day.DateId,
                CalendarDate = day,
                ShiftId = shift.Id,
                Shift = shift
            };
        }

        private static bool CanBeScheduled(Employee nurse, CalendarDate day, bool includeNightCheck = true)
        {
            if (IsAbsent(nurse, day))
            {
                return false;
            }

            if (includeNightCheck)
            {
                if (nurse.IsFixedNight)
                {
                    return false;
                }
            }

            if (HasShift(nurse, day))
            {
                return false;
            }

            return true;
        }

        private static bool HasShift(Employee nurse, CalendarDate day, string shiftName = NONE)
        {
            Shift noneShift = GetShift(nurse, shiftName.ToLower().Trim());
            return nurse.Schedules.ToList().Find(s => s.DateId == day.DateId).ShiftId != noneShift.Id;
        }

        private static Shift GetShift(Employee nurse, string shiftName)
        {
            List<Shift> shifts = nurse.Regime.Shifts.ToList();

            shiftName = shiftName.ToLower().Trim();

            return shiftName switch
            {
                EARLY => shifts.First(s => s.Name.ToLower().Trim() == shiftName),
                LATE => shifts.First(s => s.Name.ToLower().Trim() == shiftName),
                NIGHT => shifts.First(s => s.Name.ToLower().Trim() == shiftName),
                _ => shifts.First(s => s.Name.ToLower().Trim() == NONE),
            };
        }

        private static bool IsAbsent(Employee nurse, CalendarDate day)
        {
            return nurse.Absences.Any(a => a.CalendarDate.Date == day.Date);
        }

        private static void Shuffle(ref List<Employee> nurses)
        {
            Random random = new();
            for (var i = nurses.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (nurses[j], nurses[i]) = (nurses[i], nurses[j]);
            }
        }

        private static bool IsHoliday(CalendarDate day)
        {
            return !string.IsNullOrEmpty(day.HolidayName);
        }

        private static void ResetAllSchedules(ref List<Employee> nurses, List<CalendarDate> dates)
        {
            foreach (var nurse in nurses)
            {
                List<Schedule> noneSchedules = new();

                foreach (var date in dates)
                {
                    Schedule schedule = new()
                    {
                        EmployeeId = nurse.Id,
                        DateId = date.DateId,
                        ShiftId = nurse.Regime.Shifts.ToList().First(s => s.Name.ToLower().Trim() == NONE).Id
                    };

                    noneSchedules.Add(schedule);
                }

                nurse.Schedules = noneSchedules;
            }
        }
    }
}
