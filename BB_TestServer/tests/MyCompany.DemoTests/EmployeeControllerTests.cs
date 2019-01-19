using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using MyCompany.EmployeeService.Api;
using MyCompany.EmployeeService.Api.Models;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyCompany.DemoTests
{
    public class EmployeeControllerTests
    {
        private TestServer testServer = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());

        private HttpClient client;

        public EmployeeControllerTests()
        {
            client = testServer.CreateClient();
        }

        [Fact]
        public async Task GetEmployee_Should_Return_employees()
        {
            // arrange

            // act
            var response = await client.GetAsync("v1/employees").ConfigureAwait(false);

            // assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task PostEmployeeShouldReturnOk()
        {
            var employee = new CreateEmployee
            {
                SSN = "test1",
                FirstName = "Andy",
                LastName = "Andersen",
                EmailAddress = "andy.andersen@test.info",
                PhoneNumber = "123456"
            };

            var content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("v1/employees", content).ConfigureAwait(false);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
