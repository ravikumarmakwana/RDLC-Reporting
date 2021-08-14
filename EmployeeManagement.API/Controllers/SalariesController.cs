using EmployeeManagement.Business.Interfaces;
using EmployeeManagement.Entities;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmployeeManagement.API.Controllers
{
    [Route("[controller]")]
    public class SalariesController : BaseController
    {
        private readonly ISalaryService _salaryService;

        public SalariesController(ISalaryService salaryService)
        {
            _salaryService = salaryService;
        }

        [HttpGet]
        public List<Salary> GetSalaries()
        {
            return _salaryService.GetSalaries();
        }

        [HttpGet("{salaryId}")]
        public Salary GetSalaryById(int salaryId)
        {
            return _salaryService.GetSalaryById(salaryId);
        }

        [HttpGet("employees/{employeeId}")]
        public List<Salary> GetSalariesForEmployee(int employeeId)
        {
            return _salaryService.GetSalariesByEmployeeId(employeeId);
        }

        [HttpPost]
        public IActionResult AddSalary([FromBody] SalaryDto salaryDto)
        {
            _salaryService.AddSalary(salaryDto);
            return Created(string.Empty, null);
        }

        [HttpPut("{salaryId}")]
        public IActionResult UpdateSalary(int salaryId, [FromBody] SalaryDto salaryDto)
        {
            _salaryService.UpdateSalary(salaryId, salaryDto);
            return NoContent();
        }

        [HttpDelete("{salaryId}")]
        public IActionResult RemoveSalaryById(int salaryId)
        {
            _salaryService.RemoveSalary(salaryId);
            return NoContent();
        }

        [HttpDelete("employees/{employeeId}")]
        public IActionResult RemoveSalaryDetailsForEmployee(int employeeId)
        {
            _salaryService.RemoveSalaryDetailsForEmployee(employeeId);
            return NoContent();
        }
    }
}
