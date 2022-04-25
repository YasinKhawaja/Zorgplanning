using CP.DAL.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Xunit;

namespace CP.BLL.Services.Planning.Tests
{
    public class PlanningRulesTests
    {
        readonly PlanningRules _planningRules;

        public PlanningRulesTests()
        {
            ILogger<PlanningRules> logger = new Logger<PlanningRules>(new LoggerFactory());
            _planningRules = new PlanningRules(logger);
        }

        [Fact()]
        public void CheckMinimumRestPerWeekTest_1()
        {
            // Arrange
            List<Schedule> schedules = new()
            {
                new Schedule() { Shift = new Shift() { Start = new TimeSpan(7, 0, 0), End = new TimeSpan(13, 30, 0) } },
                new Schedule() { Shift = new Shift() { Start = new TimeSpan(7, 0, 0), End = new TimeSpan(13, 30, 0) } },
                new Schedule() { Shift = new Shift() { Start = new TimeSpan(7, 0, 0), End = new TimeSpan(13, 30, 0) } },
                new Schedule() { Shift = new Shift() { Start = new TimeSpan(7, 0, 0), End = new TimeSpan(13, 30, 0) } },
                new Schedule() { Shift = new Shift() { Start = new TimeSpan(7, 0, 0), End = new TimeSpan(13, 30, 0) } },
                new Schedule() { Shift = new Shift() { Start = new TimeSpan(7, 0, 0), End = new TimeSpan(13, 30, 0) } },
                new Schedule() { Shift = new Shift() { Start = new TimeSpan(7, 0, 0), End = new TimeSpan(13, 30, 0) } }
            };

            // Act
            bool hasEnoughRest = PlanningRules.CheckMinimumRestInWeek(schedules);

            // Assert
            Assert.True(hasEnoughRest);
        }

        [Fact()]
        public void CheckMinimumRestPerWeekTest_2()
        {
            // Arrange
            TimeSpan startTime = new(7, 0, 0);
            TimeSpan endTime = new(15, 0, 0);

            TimeSpan shiftHours = endTime - startTime;

            // Act
            TimeSpan workHours = new(shiftHours.Hours, shiftHours.Minutes, shiftHours.Seconds);

            // Assert
            Assert.Equal(new TimeSpan(8, 0, 0), workHours);
        }

        [Fact()]
        public void CheckMinimumRestBetweenShiftsTest()
        {
            // Arrange
            Schedule schedule1 = new()
            {
                CalendarDate = new CalendarDate() { Date = new DateTime(2022, 4, 3) },
                Shift = new Shift() { Start = new TimeSpan(7, 0, 0), End = new TimeSpan(15, 0, 0) }
            };
            Schedule schedule2 = new()
            {
                CalendarDate = new CalendarDate() { Date = new DateTime(2022, 4, 4) },
                Shift = new Shift() { Start = new TimeSpan(7, 0, 0), End = new TimeSpan(15, 0, 0) }
            };

            // Act
            bool hasEnoughRest = PlanningRules.CheckMinimumRestBetweenShifts(schedule1, schedule2);

            // Assert
            Assert.True(hasEnoughRest);
        }
    }
}
