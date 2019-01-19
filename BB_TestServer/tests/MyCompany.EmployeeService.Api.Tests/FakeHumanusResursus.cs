using MyCompany.EmployeeService.Api.Implementations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.EmployeeService.Api.Tests
{
    class FakeHumanusResursus : IHumanusResursus
    {
        public async Task<bool> SendWelcomeEmailAsync(int employeeId)
        {
            Debug.WriteLine(">>>>>>>> Fake it til you make it...");
            return await Task.FromResult(false);
        }
    }
}
