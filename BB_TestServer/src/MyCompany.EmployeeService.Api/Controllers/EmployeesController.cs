using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCompany.EmployeeService.Api.Implementations;
using MyCompany.EmployeeService.Api.Mappers;
using MyCompany.EmployeeService.Api.Models;
using MyCompany.EmployeeService.Api.Models.Out;

namespace MyCompany.EmployeeService.Api.Controllers
{
    [Produces("application/json")]
    [Route("v1/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly Services.IEmployeeService employeeService;
        private readonly IHumanusResursus humanusResursus;

        public EmployeesController(Services.IEmployeeService employeeService, IHumanusResursus humanusResursus)
        {
            this.employeeService = employeeService;
            this.humanusResursus = humanusResursus;
        }

        /// <summary>
        /// Register a new employee in the database.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <response code="200">Returns the successfully created employee.</response>
        /// <response code="400">Employee data was not correct.</response>
        /// <response code="500">Something went terribly wrong.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] CreateEmployee employee)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(", ", ModelState.Values.SelectMany(m => m.Errors).Select(m => m.ErrorMessage));
                return BadRequest(message);
            }

            var entity = EmployeesMapper.MapToEntity(employee);

            employeeService.Create(entity);

            var createdEmployee = EmployeesMapper.MapToApiModel(entity);

            await humanusResursus.SendWelcomeEmailAsync(createdEmployee.Id);

            return Ok(createdEmployee);
        }

        /// <summary>
        /// Update an existing employee in the database.
        /// </summary>
        /// <returns>A <see cref="IActionResult"/> representing the result.</returns>
        /// <response code="200">Returns the successfully updated employee.</response>
        /// <response code="400">Employee data was not correct.</response>
        /// <response code="500">Something went terribly wrong.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        public IActionResult Put(int id, [FromBody] UpdateEmployee employee)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(", ", ModelState.Values.SelectMany(m => m.Errors).Select(m => m.ErrorMessage));
                return BadRequest(message);
            }

            var entity = EmployeesMapper.MapToEntity(id, employee);

            employeeService.Update(entity);

            var createdEmployee = EmployeesMapper.MapToApiModel(entity);
            return Ok(createdEmployee);
        }

        /// <summary>
        /// Returns all registered employees.
        /// </summary>
        /// <returns>A <see cref="IActionResult"/> representing the result.</returns>
        /// <response code="200">Returns a list of all employees.</response>
        /// <response code="500">Something went terribly wrong.</response>
        [HttpGet]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(employeeService.Get());
        }

        /// <summary>
        /// Returns a registered employees with the matching id.
        /// </summary>
        /// <returns>A <see cref="IActionResult"/> representing the result.</returns>
        /// <response code="200">Returns the employee with the matching id.</response>
        /// <response code="204">No employee with given id was found.</response>
        /// <response code="500">Something went terribly wrong.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        public IActionResult Get(int id)
        {
            var employee = EmployeesMapper.MapToApiModel(employeeService.Get(id));
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }
    }
}
