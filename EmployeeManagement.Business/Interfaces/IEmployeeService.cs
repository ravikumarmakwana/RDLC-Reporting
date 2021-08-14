using EmployeeManagement.Entities;
using EmployeeManagement.Models;
using System.Collections.Generic;

namespace EmployeeManagement.Business.Interfaces
{
    public interface IEmployeeService
    {
        void AddEmployee(EmployeeDto employeeDto);
        void UpdateEmployee(int employeeId, EmployeeDto employeeDto);
        void RemoveEmployee(int employeeId);
        EmployeeDisplayDto GetEmployeeById(int employeeId);
        List<EmployeeDisplayDto> GetEmployees();
    }
}
