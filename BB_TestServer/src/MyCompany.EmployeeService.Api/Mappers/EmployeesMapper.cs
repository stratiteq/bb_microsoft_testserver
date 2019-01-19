using MyCompany.EmployeeService.Api.Models;
using MyCompany.EmployeeService.Api.Models.Out;

namespace MyCompany.EmployeeService.Api.Mappers
{
    public static class EmployeesMapper
    {
        internal static Entities.Employee MapToEntity(CreateEmployee employee)
        {
            return new Entities.Employee
            {
                SSN = employee.SSN,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                PhoneNumber = employee.PhoneNumber,
                EmailAddress = employee.EmailAddress
            };
        }

        internal static Entities.Employee MapToEntity(int id, UpdateEmployee employee)
        {
            return new Entities.Employee
            {
                Id = id,
                SSN = employee.SSN,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                PhoneNumber = employee.PhoneNumber,
                EmailAddress = employee.EmailAddress
            };
        }

        internal static Employee MapToApiModel(Entities.Employee entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new Employee
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                SSN = entity.SSN,
                EmailAddress = entity.EmailAddress,
                PhoneNumber = entity.PhoneNumber
            };
        }
    }
}
