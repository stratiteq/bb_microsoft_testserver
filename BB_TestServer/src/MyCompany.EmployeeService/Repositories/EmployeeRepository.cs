using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using MyCompany.EmployeeService.Entities;

namespace MyCompany.EmployeeService.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private ConcurrentDictionary<int, Employee> db;

        public EmployeeRepository()
        {
            db = new ConcurrentDictionary<int, Employee>();

            //For demo purposes
            var testEmployee1 = new Employee
            {
                Id = 10000001,
                FirstName = "Anders",
                LastName = "Andersson",
                SSN = "19121212-1212",
                EmailAddress = "anders.andersson@test.info",
                PhoneNumber = "001002"
            };

            var testEmployee2 = new Employee
            {
                Id = 10000002,
                FirstName = "Bengt",
                LastName = "Bengtsson",
                SSN = "19121212-1211",
                EmailAddress = "bengt.bengtsson@test.info",
                PhoneNumber = "001003"
            };

            db.AddOrUpdate(testEmployee1.Id, testEmployee1, (id, emp) => testEmployee1);
            db.AddOrUpdate(testEmployee2.Id, testEmployee2, (id, emp) => testEmployee2);
        }

        public Employee Get(int id)
        {
            db.TryGetValue(id, out var employee);
            return employee;
        }

        public IEnumerable<Employee> Get()
        {
            return db.Values;
        }

        public void Save(Employee employee)
        {
            db.AddOrUpdate(employee.Id, employee, (id, emp) => employee);
        }
    }
}
