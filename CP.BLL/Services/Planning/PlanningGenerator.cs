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

        readonly List<Employee> _nurses;
        readonly List<CalendarDate> _month;

        public PlanningGenerator(List<Employee> nurses, List<CalendarDate> month)
        {
            _nurses = nurses;
            _month = month;
        }

        public List<Employee> GenerateMonthlyPlanning(List<Employee> nurses, List<CalendarDate> month)
        {
            if (nurses.Count < 5 || !month.Any())
            {
                throw new Exception("NO DATA");
            }

            ClearAllSchedules(ref nurses, ref month);

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
                }

                while (!HasMinimumOccupancyEarly(day))
                {
                    Employee nurseForEarly = FindAvailableNurse(nurses, day, EARLY);
                    Schedule earlySchedule = BuildSchedule(nurseForEarly, day, GetShift(nurseForEarly, EARLY));
                    nurses.Find(n => n.Id == nurseForEarly.Id).Schedules =
                        UpdateNurseSchedules(nurseForEarly, earlySchedule);
                    day.Schedules = UpdateDaySchedules(day, earlySchedule);
                }

                while (!HasMinimumOccupancyLate(day))
                {
                    Employee nurseForLate = FindAvailableNurse(nurses, day, LATE);
                    Schedule lateSchedule = BuildSchedule(nurseForLate, day, GetShift(nurseForLate, LATE));
                    nurses.Find(n => n.Id == nurseForLate.Id).Schedules =
                        UpdateNurseSchedules(nurseForLate, lateSchedule);
                    day.Schedules = UpdateDaySchedules(day, lateSchedule);
                }

                while (!HasMinimumOccupancyNight(day))
                {
                    Employee nurseForNight = FindAvailableNurse(nurses, day, NIGHT);
                    Schedule nightSchedule = BuildSchedule(nurseForNight, day, GetShift(nurseForNight, NIGHT));
                    nurses.Find(n => n.Id == nurseForNight.Id).Schedules =
                        UpdateNurseSchedules(nurseForNight, nightSchedule);
                    day.Schedules = UpdateDaySchedules(day, nightSchedule);
                }
            }

            return nurses;
        }

        private static Employee FindAvailableNurseEarly(List<Employee> nurses, CalendarDate day)
        {
            throw new NotImplementedException();
        }

        private static Employee FindAvailableNurseLate(List<Employee> nurses, CalendarDate day)
        {
            throw new NotImplementedException();
        }

        private Employee FindAvailableNurseNight(List<Employee> nurses, CalendarDate day)
        {
            List<Employee> nursesNight = nurses.OrderByDescending(n => n.IsFixedNight).ToList();

            List<DateTime> week = GetWeek(day.Date);
            List<CalendarDate> weekCDs = _month.FindAll(d => week.Contains(d.Date));

            List<Employee> availableNursesNight = new();

            foreach (var nurse in nursesNight)
            {
                if (HasShift(nurse, day))
                {
                    continue;
                }

                double hoursToBeWorked = nurse.Regime.Hours;
                double hoursWorked = 0;

                List<Schedule> schedulesInWeek = GetSchedulesInWeek(nurse, weekCDs);

                foreach (var schedule in schedulesInWeek)
                {
                    DateTime startTime = schedule.CalendarDate.Date;
                    startTime = startTime.AddHours(schedule.Shift.Start.Hours);
                    startTime = startTime.AddMinutes(schedule.Shift.Start.Minutes);

                    DateTime endTime = schedule.CalendarDate.Date.AddDays(1);
                    endTime = endTime.AddHours(schedule.Shift.End.Hours);
                    endTime = endTime.AddMinutes(schedule.Shift.End.Minutes);

                    double duration = endTime.Subtract(startTime).TotalHours;

                    if (duration == 24) { hoursWorked += 0; } else { hoursWorked += duration; }
                }

                if (hoursWorked >= hoursToBeWorked)
                {
                    continue;
                }

                availableNursesNight.Add(nurse);
            }

            if (!availableNursesNight.Any())
            {
                throw new Exception("No available nurses");
            }

            if (availableNursesNight.Any(n => n.IsFixedNight))
            {
                availableNursesNight = availableNursesNight.Where(n => n.IsFixedNight).ToList();
            }

            return GetRandomNurse(availableNursesNight);
        }

        private static List<Schedule> GetSchedulesInWeek(Employee nurse, List<CalendarDate> week)
        {
            List<Schedule> schedulesInWeek = new();
            List<Schedule> schedules = week.Select(d => d.Schedules.ToList()
                                                                   .Find(s => s.Employee.Id == nurse.Id)).ToList();
            schedulesInWeek.AddRange(schedules);
            schedulesInWeek.RemoveAll(s => s is null);
            return schedulesInWeek;
        }

        private static List<DateTime> GetWeek(DateTime date)
        {
            int currentDayOfWeek = (int)date.DayOfWeek;
            DateTime sunday = date.AddDays(-currentDayOfWeek);
            DateTime monday = sunday.AddDays(1);

            if (currentDayOfWeek == 0)
            {
                monday = monday.AddDays(-7);
            }

            return Enumerable
                .Range(0, 7)
                .Select(days => monday.AddDays(days))
                .ToList();
        }

        private static bool HasShift(Employee nurse, CalendarDate day)
        {
            return nurse.Schedules.ToList().Find(s => s.DateId == day.Id) is not null;
        }

        private Employee FindAvailableNurse(List<Employee> nurses, CalendarDate day, string shiftName)
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

        private static IEnumerable<Schedule> UpdateDaySchedules(CalendarDate day, Schedule schedule)
        {
            List<Schedule> schedulesDay = day.Schedules.ToList();
            schedulesDay.Add(schedule);
            return schedulesDay.OrderBy(s => s.CalendarDate.Date).ToList();
        }

        private static IEnumerable<Schedule> UpdateNurseSchedules(Employee nurse, Schedule schedule)
        {
            List<Schedule> schedulesNurse = nurse.Schedules.ToList();
            schedulesNurse.Add(schedule);
            return schedulesNurse.OrderBy(s => s.CalendarDate.Date).ToList();
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
