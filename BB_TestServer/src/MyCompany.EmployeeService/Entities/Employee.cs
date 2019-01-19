using Newtonsoft.Json;
using System;

namespace MyCompany.EmployeeService.Entities
{
    public class Employee
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("ssn")]
        public string SSN { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }
    }
}
