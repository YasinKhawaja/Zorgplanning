using CP.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CP.DAL
{
    public static class DbSeeder
    {
        public static void Seed(this ModelBuilder builder)
        {
            #region Teams
            builder.Entity<Team>().HasData(
                new Team
                {
                    Id = 1,
                    Name = "Team A"
                });
            #endregion

            #region Regimes
            builder.Entity<Regime>().HasData(
                new Regime
                {
                    Id = 1,
                    Name = "Voltijds",
                    Hours = 38,
                    Percentage = 100
                },
                new Regime
                {
                    Id = 2,
                    Name = "Deeltijds 4/5",
                    Hours = 30.4,
                    Percentage = 80
                },
                new Regime
                {
                    Id = 3,
                    Name = "Deeltijds 3/4",
                    Hours = 28.8,
                    Percentage = 75
                },
                new Regime
                {
                    Id = 4,
                    Name = "Halftijds",
                    Hours = 19,
                    Percentage = 50
                });
            #endregion

            #region Employees
            builder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    FirstName = "Emp1",
                    LastName = "Emp1",
                    TeamId = 1,
                    RegimeId = 1
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Emp2",
                    LastName = "Emp2",
                    TeamId = 1,
                    RegimeId = 1
                },
                new Employee
                {
                    Id = 3,
                    FirstName = "Emp3",
                    LastName = "Emp3",
                    TeamId = 1,
                    RegimeId = 1
                },
                new Employee
                {
                    Id = 4,
                    FirstName = "Emp4",
                    LastName = "Emp4",
                    TeamId = 1,
                    RegimeId = 1
                },
                new Employee
                {
                    Id = 5,
                    FirstName = "Emp5",
                    LastName = "Emp5",
                    TeamId = 1,
                    RegimeId = 2
                },
                new Employee
                {
                    Id = 6,
                    FirstName = "Emp6",
                    LastName = "Emp6",
                    TeamId = 1,
                    RegimeId = 2
                },
                new Employee
                {
                    Id = 7,
                    FirstName = "Emp7",
                    LastName = "Emp7",
                    TeamId = 1,
                    RegimeId = 2
                },
                new Employee
                {
                    Id = 8,
                    FirstName = "Emp8",
                    LastName = "Emp8",
                    TeamId = 1,
                    RegimeId = 3
                },
                new Employee
                {
                    Id = 9,
                    FirstName = "Emp9",
                    LastName = "Emp9",
                    TeamId = 1,
                    RegimeId = 3
                },
                new Employee
                {
                    Id = 10,
                    FirstName = "Emp10",
                    LastName = "Emp10",
                    IsFixedNight = true,
                    TeamId = 1,
                    RegimeId = 1
                },
                new Employee
                {
                    Id = 11,
                    FirstName = "Emp11",
                    LastName = "Emp11",
                    IsFixedNight = true,
                    TeamId = 1,
                    RegimeId = 1
                },
                new Employee
                {
                    Id = 12,
                    FirstName = "Emp12",
                    LastName = "Emp12",
                    IsFixedNight = true,
                    TeamId = 1,
                    RegimeId = 3
                });
            #endregion

            #region Shifts
            builder.Entity<Shift>().HasData(
                new Shift
                {
                    Id = 1,
                    Name = "Vroeg",
                    Start = new TimeSpan(7, 0, 0),
                    End = new TimeSpan(15, 0, 0),
                    RegimeId = 1
                },
                new Shift
                {
                    Id = 2,
                    Name = "Vroeg",
                    Start = new TimeSpan(7, 0, 0),
                    End = new TimeSpan(13, 30, 0),
                    RegimeId = 2
                },
                new Shift
                {
                    Id = 3,
                    Name = "Vroeg",
                    Start = new TimeSpan(7, 0, 0),
                    End = new TimeSpan(13, 30, 0),
                    RegimeId = 3
                },
                new Shift
                {
                    Id = 4,
                    Name = "Vroeg",
                    Start = new TimeSpan(7, 0, 0),
                    End = new TimeSpan(11, 0, 0),
                    RegimeId = 4
                },
                new Shift
                {
                    Id = 5,
                    Name = "Laat",
                    Start = new TimeSpan(12, 30, 0),
                    End = new TimeSpan(20, 30, 0),
                    RegimeId = 1
                },
                new Shift
                {
                    Id = 6,
                    Name = "Laat",
                    Start = new TimeSpan(14, 0, 0),
                    End = new TimeSpan(20, 30, 0),
                    RegimeId = 2
                },
                new Shift
                {
                    Id = 7,
                    Name = "Laat",
                    Start = new TimeSpan(14, 0, 0),
                    End = new TimeSpan(20, 30, 0),
                    RegimeId = 3
                },
                new Shift
                {
                    Id = 8,
                    Name = "Laat",
                    Start = new TimeSpan(16, 0, 0),
                    End = new TimeSpan(20, 0, 0),
                    RegimeId = 4
                },
                new Shift
                {
                    Id = 9,
                    Name = "Nacht",
                    Start = new TimeSpan(20, 15, 0),
                    End = new TimeSpan(07, 15, 0),
                    RegimeId = 1
                },
                new Shift
                {
                    Id = 10,
                    Name = "Nacht",
                    Start = new TimeSpan(20, 15, 0),
                    End = new TimeSpan(07, 15, 0),
                    RegimeId = 2
                },
                new Shift
                {
                    Id = 11,
                    Name = "Nacht",
                    Start = new TimeSpan(20, 15, 0),
                    End = new TimeSpan(07, 15, 0),
                    RegimeId = 3
                },
                new Shift
                {
                    Id = 12,
                    Name = "Nacht",
                    Start = new TimeSpan(20, 15, 0),
                    End = new TimeSpan(07, 15, 0),
                    RegimeId = 4
                },
                new Shift
                {
                    Id = 13,
                    Name = "Geen",
                    Start = new TimeSpan(0, 0, 0),
                    End = new TimeSpan(0, 0, 0),
                    RegimeId = 1
                },
                new Shift
                {
                    Id = 14,
                    Name = "Geen",
                    Start = new TimeSpan(0, 0, 0),
                    End = new TimeSpan(0, 0, 0),
                    RegimeId = 2
                },
                new Shift
                {
                    Id = 15,
                    Name = "Geen",
                    Start = new TimeSpan(0, 0, 0),
                    End = new TimeSpan(0, 0, 0),
                    RegimeId = 3
                },
                new Shift
                {
                    Id = 16,
                    Name = "Geen",
                    Start = new TimeSpan(0, 0, 0),
                    End = new TimeSpan(0, 0, 0),
                    RegimeId = 4
                });
            #endregion

            #region CalendarDates
            int dateId = 1;
            List<CalendarDate> dates = new();
            for (DateTime date = new(2022, 1, 1); date <= new DateTime(2022, 12, 31); date = date.AddDays(1))
            {
                dates.Add(new CalendarDate() { DateId = dateId, Date = date });
                dateId++;
            }
            builder.Entity<CalendarDate>().HasData(dates);
            #endregion
        }
    }
}
