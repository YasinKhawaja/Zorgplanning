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
    public class TeamsControllerTests : IClassFixture<TestingWebAppFactory<Program>>
    {
        private readonly HttpClient _client;

        public TeamsControllerTests(TestingWebAppFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact, Priority(1)]
        public async Task GetAsyncTestAsync()
        {
            // Arrange
            string uri = "https://localhost:7224/api/teams";
            TeamDTO teamDTO = new() { Id = 0, Name = "Team Test A", HasChildren = false };
            HttpContent content = new StringContent(
                JsonConvert.SerializeObject(teamDTO), Encoding.UTF8, "application/json");

            await _client.PostAsync(uri, content);

            // Act
            HttpResponseMessage response = await _client.GetAsync($"{uri}/1");
            string contentStr = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Contains(teamDTO.Name, contentStr);
        }

        [Fact, Priority(2)]
        public async Task PostAsyncTestAsync()
        {
            // Arrange
            Uri uri = new("https://localhost:7224/api/teams");
            TeamDTO teamDTO = new() { Id = 0, Name = "Team Test B", HasChildren = false };
            HttpContent content = new StringContent(
                JsonConvert.SerializeObject(teamDTO), Encoding.UTF8, "application/json");

            // Act
            HttpResponseMessage response = await _client.PostAsync(uri, content);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
