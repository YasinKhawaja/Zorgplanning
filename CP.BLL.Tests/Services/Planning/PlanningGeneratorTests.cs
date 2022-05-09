using CP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CP.BLL.Services.Planning.Tests
{
    public class PlanningGeneratorTests
    {
        [Fact()]
        public void GenerateBasicPlanningTest()
        {
            // Arrange
            List<Employee> nurses = new() {
                new Employee() {
                    Id = 1,
                    Regime = new Regime() {
                        Id = 2,
                        Shifts = new List<Shift>() {
                            new Shift() {
                                Id = 3,
                                Name = "Vroeg"
                            }
                        }
                    },
                    Schedules = new List<Schedule>()
                }
            };

            List<CalendarDate> dates = new();
            for (int i = 1; i <= 31; i++)
            {
                dates.Add(new CalendarDate() { Id = i, Date = new DateTime(2022, 1, i) });
            }

            // Act
            List<Employee> nurses1 = new();/*PlanningGenerator.GenerateBasicPlanning(nurses, dates);*/

            // Assert
            Assert.Equal(dates.Count, nurses1.First().Schedules.Count());
            Assert.Equal(3, nurses1.First().Schedules.First().ShiftId);
        }
    }
}
