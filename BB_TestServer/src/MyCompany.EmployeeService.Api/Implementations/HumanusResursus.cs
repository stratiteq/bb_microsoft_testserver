using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.EmployeeService.Api.Implementations
{
    public class HumanusResursus : IHumanusResursus
    {
        public async Task<bool> SendWelcomeEmailAsync(int employeeId)
        {
            // Code to connect to the HR system and 
            //send a welcome email to the new employee goes here
            Debug.WriteLine("*****>>>>> Sending email through HR service...");

            await Task.Delay(2500);

            return true;
        }
    }
}
