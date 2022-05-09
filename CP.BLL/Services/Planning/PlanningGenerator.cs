using CP.DAL.Models;

namespace CP.BLL.Services.Planning
{
    public class PlanningGenerator
    {
        const string NONE = "geen";
        const string EARLY = "vroeg";
        const string LATE = "laat";
        const string NIGHT = "nacht";
        const int MAX_ATTEMPTS = 50;

        public static List<Employee> GenerateMonthlyPlanning(List<Employee> nurses, List<CalendarDate> month)
        {
            if (!nurses.Any() || !month.Any())
            {
                throw new Exception("NO DATA");
            } // works

            ClearAllSchedules(ref nurses, ref month); // works

            foreach (var day in month)
            {
                if (IsHoliday(day))
                {
                    nurses.ForEach(nurse =>
                    {
                        Schedule noneSchedule = BuildSchedule(nurse, day, GetShift(nurse, NONE));
                        nurse.Schedules = UpdateNurseSchedules(nurse, noneSchedule);
                        day.Schedules = UpdateDaySchedules(day, noneSchedule);
                    });
                    continue;
                } // works

                // BACKTRACKING ALGORITHM?

                //while (!HasMinimumOccupancy(day))
                //{
                //    Employee nurse = FindAvailableNurse(nurses, day, EARLY);

                //    Schedule newSchedule = BuildSchedule(nurse, day, GetShift(nurse, EARLY));
                //}

                while (!HasMinimumOccupancyNight(day))
                {
                    Employee nurseForNight = FindAvailableNurse(nurses, day, NIGHT);
                    Schedule nightSchedule = BuildSchedule(nurseForNight, day, GetShift(nurseForNight, NIGHT));
                    nurses.Find(n => n.Id == nurseForNight.Id).Schedules = UpdateNurseSchedules(nurseForNight, nightSchedule);
                    day.Schedules = UpdateDaySchedules(day, nightSchedule);
                } // works
            }

            var newNurses = nurses;
            return newNurses;
        }

        private static Employee FindAvailableNurseNight(List<Employee> nurses, CalendarDate day)
        {
            List<Employee> nightNurses = new();

            if (nurses.FindAll(n => n.IsFixedNight).Any())
            {
                nightNurses.AddRange(nurses.FindAll(n => n.IsFixedNight));
            }
            else
            {
                nightNurses.AddRange(nurses.Where(nurse => !nurse.Schedules.Any(s => s.DateId == day.Id)));
            }

            return GetRandomNurse(nightNurses);
        }

        private static IEnumerable<Schedule> UpdateDaySchedules(CalendarDate day, Schedule schedule)
        {
            List<Schedule> schedulesDay = day.Schedules.ToList();
            schedulesDay.Add(schedule);
            return schedulesDay;
        }

        private static IEnumerable<Schedule> UpdateNurseSchedules(Employee nurse, Schedule schedule)
        {
            List<Schedule> schedulesNurse = nurse.Schedules.ToList();
            schedulesNurse.Add(schedule);
            return schedulesNurse;
        }

        private static Employee FindAvailableNurse(List<Employee> nurses, CalendarDate day, string shiftName)
        {
            Employee nurse = null;
            switch (shiftName)
            {
                case EARLY:
                    nurse = FindAvailableNurseEarly(nurses, day);
                    break;
                case LATE:
                    nurse = FindAvailableNurseLate(nurses, day);
                    break;
                case NIGHT:
                    nurse = FindAvailableNurseNight(nurses, day);
                    break;
                default:
                    break;
            }
            return nurse;
        }

        private static Employee FindAvailableNurseLate(List<Employee> nurses, CalendarDate day)
        {
            throw new NotImplementedException();
        }

        private static Employee FindAvailableNurseEarly(List<Employee> nurses, CalendarDate day)
        {
            throw new NotImplementedException();
        }

        private static Employee GetRandomNurse(List<Employee> nurses)
        {
            int index = new Random().Next(0, nurses.Count);
            Employee nurse = nurses[index];
            return nurse;
        }

        private static bool HasMinimumOccupancy(CalendarDate day)
        {
            return HasMinimumOccupancyEarly(day) && HasMinimumOccupancyLate(day) && HasMinimumOccupancyNight(day);
        }

        private static bool HasMinimumOccupancyEarly(CalendarDate day)
        {
            return true;
        }

        private static bool HasMinimumOccupancyLate(CalendarDate day)
        {
            return true;
        }

        private static bool HasMinimumOccupancyNight(CalendarDate day)
        {
            return day.Schedules
                .ToList()
                .FindAll(s => s.Shift.Name.ToLower() == NIGHT)
                .Any();
        }

        private static Schedule BuildSchedule(Employee nurse, CalendarDate day, Shift shift)
        {
            return new Schedule()
            {
                EmployeeId = nurse.Id,
                Employee = nurse,
                DateId = day.Id,
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
            return nurse.Schedules.ToList().Find(s => s.DateId == day.Id).ShiftId != noneShift.Id;
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

        private static void ClearAllSchedules(ref List<Employee> nurses, ref List<CalendarDate> month)
        {
            foreach (var nurse in nurses)
            {
                List<Schedule> schedulesNurse = nurse.Schedules.ToList();
                schedulesNurse.Clear();
                nurse.Schedules = schedulesNurse;
            }

            foreach (var day in month)
            {
                List<Schedule> schedulesDay = day.Schedules.ToList();
                schedulesDay.Clear();
                day.Schedules = schedulesDay;
            }
        }
    }
}
