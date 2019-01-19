using MyCompany.EmployeeService.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompany.EmployeeService.Repositories
{
    public interface IEmployeeRepository
    {
        void Save(Employee employee);

        IEnumerable<Employee> Get();

        Employee Get(int id);
    }
}
