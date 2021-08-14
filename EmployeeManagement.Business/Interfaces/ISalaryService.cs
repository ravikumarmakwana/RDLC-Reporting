using EmployeeManagement.Entities;
using EmployeeManagement.Models;
using System.Collections.Generic;

namespace EmployeeManagement.Business.Interfaces
{
    public interface ISalaryService
    {
        void AddSalary(SalaryDto salaryDto);
        void UpdateSalary(int salaryId, SalaryDto salaryDto);
        void RemoveSalary(int salaryId);
        void RemoveSalaryDetailsForEmployee(int employeeId);
        List<Salary> GetSalariesByEmployeeId(int employeeId);
        List<Salary> GetSalaries();
        Salary GetSalaryById(int salaryId);
    }
}
