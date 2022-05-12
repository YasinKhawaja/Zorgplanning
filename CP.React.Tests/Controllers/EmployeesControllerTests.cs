using CP.BLL.DTOs;
using CP.React.Tests;
using Newtonsoft.Json;
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
        private readonly HttpClient _client;

        public EmployeesControllerTests(TestingWebAppFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact, Priority(1)]
        public async Task GetAsyncTestAsync()
        {
            // Arrange
            string uri = "https://localhost:7224/api/employees";
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

            await _client.PostAsync(uri, content);

            // Act
            HttpResponseMessage response = await _client.GetAsync($"{uri}/1");
            string contentStr = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Contains(employeeDTO.FirstName, contentStr);
        }

        [Fact, Priority(2)]
        public async Task PostAsyncTestAsync()
        {
            // Arrange
            string uri = "https://localhost:7224/api/employees";
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

            await _client.PostAsync(uri, content);

            // Act
            HttpResponseMessage response = await _client.GetAsync($"{uri}/1");

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
