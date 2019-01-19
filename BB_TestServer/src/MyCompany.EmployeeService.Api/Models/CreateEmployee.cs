using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MyCompany.EmployeeService.Api.Models
{
    public class CreateEmployee
    {
        [JsonProperty("ssn", Required = Required.Always)]
        public string SSN { get; set; }

        [JsonProperty("firstName", Required = Required.Always)]
        public string FirstName { get; set; }

        [JsonProperty("lastName", Required = Required.Always)]
        public string LastName { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }
    }
}
