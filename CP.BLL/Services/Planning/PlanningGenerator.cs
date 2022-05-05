using CP.DAL.Models;

namespace CP.BLL.Services.Planning
{
    public class PlanningGenerator
    {

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

                // Plan early schedules.
                foreach (var nurse in nurses)
                {
                    if (IsAbsent(nurse, day))
                    {
                        continue;
                    }

                    if (nurse.IsFixedNight)
                    {
                        continue;
                    }

                    nurse.Schedules
                        .ToList()
                        .Find(s => s.DateId == day.DateId)
                        .ShiftId = GetShiftId(nurse, "vroeg");
                }

                // Plan late schedules.
                foreach (var nurse in nurses)
                {
                    if (IsAbsent(nurse, day))
                    {
                        continue;
                    }

                    if (nurse.IsFixedNight)
                    {
                        continue;
                    }

                    nurse.Schedules
                        .ToList()
                        .Find(s => s.DateId == day.DateId)
                        .ShiftId = GetShiftId(nurse, "laat");
                }

                // Plan night schedule.
                foreach (var nurse in nurses)
                {
                    if (IsAbsent(nurse, day))
                    {
                        continue;
                    }

                    if (nurse.IsFixedNight)
                    {
                        continue;
                    }

                    nurse.Schedules
                        .ToList()
                        .Find(s => s.DateId == day.DateId)
                        .ShiftId = GetShiftId(nurse, "nacht");
                }
            }

            return nurses;
        }

        private static int GetShiftId(Employee nurse, string shiftName)
        {
            List<Shift> shifts = nurse.Regime.Shifts.ToList();

            shiftName = shiftName.ToLower().Trim();

            switch (shiftName)
            {
                case "vroeg":
                    return shifts.First(s => s.Name.ToLower().Trim() == shiftName).Id;
                case "laat":
                    return shifts.First(s => s.Name.ToLower().Trim() == shiftName).Id;
                case "nacht":
                    return shifts.First(s => s.Name.ToLower().Trim() == shiftName).Id;
                default:
                    return shifts.First(s => s.Name.ToLower().Trim() == shiftName).Id;
            }
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
                        ShiftId = nurse.Regime.Shifts.ToList().First(s => s.Name.ToLower().Trim() == "geen").Id
                    };

                    noneSchedules.Add(schedule);
                }

                nurse.Schedules = noneSchedules;
            }
        }
    }
}
