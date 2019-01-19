using System;
using System.Collections.Generic;
using System.Text;
using MyCompany.EmployeeService.Entities;
using MyCompany.EmployeeService.Repositories;

namespace MyCompany.EmployeeService.Services
{
    public class EmployeeService : IEmployeeService
    {
        private static int id = 1;
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public void Create(Employee employee)
        {
            employee.Id = id++;
            employeeRepository.Save(employee);
        }

        public IEnumerable<Employee> Get()
        {
            return employeeRepository.Get();
        }

        public Employee Get(int id)
        {
            return employeeRepository.Get(id);
        }

        public void Update(Employee employee)
        {
            employeeRepository.Save(employee);
        }
    }
}
