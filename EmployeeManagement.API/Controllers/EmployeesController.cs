using EmployeeManagement.Business.Interfaces;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmployeeManagement.API.Controllers
{
    [Route("[controller]")]
    public class EmployeesController : BaseController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public List<EmployeeDisplayDto> GetEmployees()
        {
            return _employeeService.GetEmployees();
        }

        [HttpGet("{employeeId}")]
        public EmployeeDisplayDto GetEmployees(int employeeId)
        {
            return _employeeService.GetEmployeeById(employeeId);
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] EmployeeDto employeeDto)
        {
            _employeeService.AddEmployee(employeeDto);
            return Created(string.Empty, null);
        }

        [HttpPut("{employeeId}")]
        public IActionResult UpdateEmployee(int employeeId, [FromBody] EmployeeDto employeeDto)
        {
            _employeeService.UpdateEmployee(employeeId, employeeDto);
            return NoContent();
        }

        [HttpDelete("{employeeId}")]
        public IActionResult RemoveEmployee(int employeeId)
        {
            _employeeService.RemoveEmployee(employeeId);
            return NoContent();
        }
    }
}
