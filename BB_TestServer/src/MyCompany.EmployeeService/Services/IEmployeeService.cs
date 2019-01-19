using MyCompany.EmployeeService.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompany.EmployeeService.Services
{
    public interface IEmployeeService
    {
        void Create(Employee employee);

        void Update(Employee employee);

        IEnumerable<Employee> Get();

        Employee Get(int id);
    }
}
