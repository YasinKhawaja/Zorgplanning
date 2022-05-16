using CP.BLL.DTOs;
using CP.React.Tests;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Priority;

namespace CP.React.Controllers.Tests
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class EmployeesControllerTests : IClassFixture<TestingWebAppFactory<Program>>
    {
        const string URI = "https://localhost:7224/api/employees";

        private readonly HttpClient _client;

        public EmployeesControllerTests(TestingWebAppFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact, Priority(1)]
        public async Task GetAsyncTestAsync()
        {
            // Arrange
            EmployeeDTO employeeDTO = new()
            {
                Id = 0,
                FirstName = "John",
                LastName = "Doe",
                IsFixedNight = false,
                TeamId = 1,
                RegimeId = 1
            };
            HttpContent content = new StringContent(
                JsonConvert.SerializeObject(employeeDTO), Encoding.UTF8, "application/json");

            await _client.PostAsync(URI, content);

            // Act
            HttpResponseMessage response = await _client.GetAsync($"{URI}/1");
            string contentStr = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Contains(employeeDTO.FirstName, contentStr);
        }

        [Fact, Priority(2)]
        public async Task PostAsyncTestAsync()
        {
            // Arrange
            EmployeeDTO employeeDTO = new()
            {
                Id = 0,
                FirstName = "Eva",
                LastName = "Doe",
                IsFixedNight = false,
                TeamId = 1,
                RegimeId = 1
            };
            HttpContent content = new StringContent(
                JsonConvert.SerializeObject(employeeDTO), Encoding.UTF8, "application/json");

            // Act
            HttpResponseMessage response = await _client.PostAsync(URI, content);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact, Priority(3)]
        public async Task PostAbsenceAsyncTestAsync()
        {
            // Arrange
            EmployeeDTO employeeDTO = new()
            {
                Id = 0,
                FirstName = "John",
                LastName = "Doe",
                IsFixedNight = false,
                TeamId = 1,
                RegimeId = 1
            };

            HttpContent contentEmp = new StringContent(
                JsonConvert.SerializeObject(employeeDTO), Encoding.UTF8, "application/json");

            await _client.PostAsync(URI, contentEmp);
            //await _client.PostAsync(URI, contentDate);

            AbsenceDTO absenceDTO = new() { EmployeeId = 1, Day = new DateTime(2022, 1, 1), Type = "Leave" };

            HttpContent content = new StringContent(
                JsonConvert.SerializeObject(absenceDTO), Encoding.UTF8, "application/json");

            // Act
            HttpResponseMessage response = await _client.PostAsync($"{URI}/1/absences", content);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact, Priority(4)]
        public void DeleteAbsenceAsyncTest()
        {
            Assert.True(false, "This test needs an implementation");
        }
    }
}
