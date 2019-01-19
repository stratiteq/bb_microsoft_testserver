using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.EmployeeService.Api.Implementations
{
    public interface IHumanusResursus
    {
        Task<bool> SendWelcomeEmailAsync(int employeeId);
    }
}
