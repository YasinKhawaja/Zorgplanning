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
            ResetAllSchedules(ref nurses, ref month);

            foreach (var day in month)
            {
                if (IsHoliday(day)) { continue; }

                List<Schedule> newSchedulesOnDay = day.Schedules.ToList();

                while (newSchedulesOnDay.FindAll(s => s.Shift.Name.ToLower() == EARLY).Count >= 2)
                {
                    Employee nurse1 = FindAvailableNurse(nurses, day, EARLY);

                    Schedule newSchedule = BuildSchedule(nurse1, day, GetShift(nurse1, EARLY));

                    Schedule oldSchedule = newSchedulesOnDay.Find(s => s.EmployeeId == day.DateId);

                    newSchedulesOnDay.Remove(oldSchedule);
                    newSchedulesOnDay.Add(newSchedule);

                    IOrderedEnumerable<Schedule> schedules = newSchedulesOnDay.OrderBy(s => s.DateId);
                    newSchedulesOnDay.Clear();
                    newSchedulesOnDay = schedules.ToList();
                }

                //int attempts = 1;
                //while (!PlanningRules.HasGuaranteedOccupation(day) && attempts <= MAX_ATTEMPTS)
                //{

                //// 1. Get a random nurse
                //Employee nurse = GetRandomNurse(ref nurses);

                //// 2. Get a random shift
                //Shift shift = GetRandomShift(nurse);

                //// 3. Check if the shift is available
                //if (IsShiftAvailable(day, shift))
                //{
                //    // 4. Add the shift to the day
                //    AddShiftToDay(day, shift);
                //}

                //// 5. Check if the day is full
                //if (PlanningRules.IsDayFull(day))
                //{
                //    // 6. Remove the last shift
                //    RemoveLastShift(day);
                //}

                //attempts++;
                //if (attempts == (MAX_ATTEMPTS + 1))
                //{
                //    throw new Exception("COULD NOT GENERATE PLANNING: MAX ATTEMPTS REACHED");
                //}
                //}

                List<Employee> remainingNursesForEarly = nurses.ToList();

                List<Employee> nursesLate = remainingNursesForEarly.ToList();

                foreach (var nurse in remainingNursesForEarly)
                {
                    if (IsAbsent(nurse, day))
                    {
                        Schedule noneSchedule = BuildSchedule(nurse, day, GetShift(nurse, NONE));
                        //schedulesForDay.Add(noneSchedule);
                        nursesLate.Remove(nurse);
                        continue;
                    }

                    if (nurse.IsFixedNight) { continue; }

                    Schedule schedule = new();

                    //if (schedulesForDay.FindAll(s => s.Shift.Name.ToLower() == EARLY).Count < 2)
                    //{
                    //    schedule = BuildSchedule(nurse, day, GetShift(nurse, EARLY));
                    //}

                    nurse.Schedules.ToList().Find(s => s.DateId == schedule.DateId).ShiftId = schedule.ShiftId;
                    //schedulesForDay.Add(schedule);
                    nursesLate.Remove(nurse);
                }
            }

            return nurses;
        }

        private static Employee FindAvailableNurse(List<Employee> nurses, CalendarDate date, string eARLY)
        {
            Shuffle(ref nurses);
            return GetRandomNurse(nurses);
        }

        private static Employee GetRandomNurse(List<Employee> nurses)
        {
            int index = new Random().Next(0, nurses.Count);
            Employee nurse = nurses[index];
            return nurse;
        }

        private static bool CheckMinimumOccupancy(CalendarDate day)
        {
            return day.Schedules.ToList().FindAll(s => s.Shift.Name == "vroeg").Count < 2;
        }

        private static Schedule BuildSchedule(Employee nurse, CalendarDate day, Shift shift)
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

        private static void ResetAllSchedules(ref List<Employee> nurses, ref List<CalendarDate> dates)
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

                    date.Schedules.ToList().Find(s => s.EmployeeId == nurse.Id).ShiftId = schedule.ShiftId;
                    noneSchedules.Add(schedule);
                }

                nurse.Schedules = noneSchedules;
            }
        }
    }
}
