using FluentAssertions;
using MyCompany.EmployeeService.Api.Models;
using MyCompany.EmployeeService.Api.Models.Out;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyCompany.EmployeeService.Api.Tests
{
    public class EmployeesControllerTests
    {
        private HttpClient client;

        public EmployeesControllerTests()
        {
            client = new TestServerprovider().Client;
        }

        [Fact]
        public async Task Test1()
        {
            var actual = await client.GetAsync("v1/employees/10000001");

            actual.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Test2()
        {
            var response = await client.GetAsync("v1/employees/10000001");
            var content = await response.Content.ReadAsStringAsync();
            var actual = JsonConvert.DeserializeObject<Employee>(content);

            actual.FirstName.Should().Be("Anders");
        }


        [Fact]
        public async Task ShouldPostEmployee()
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

            // act
            var response = await client.PostAsync("v1/employees", content);

            // assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task When_invalid_model_Then_statusCode_should_be_BadRequest()
        {
            var employee = new JObject
            {
                new JProperty("FirstName", "John"),
                new JProperty("LastName", "Doe"),
            };

            var content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");

            // act
            var response = await client.PostAsync("v1/employees", content);

            // assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

    }
}
