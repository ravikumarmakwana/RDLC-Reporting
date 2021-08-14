using System.Collections.Generic;

namespace EmployeeManagement.Entities.Interfaces
{
    public interface IEmployeeRepository
    {
        void AddEmployee(Employee employee);
        void UpdateEmployee(int employeeId, Employee employee);
        void RemoveEmployee(int employeeId);
        Employee GetEmployeeById(int employeeId);
        List<Employee> GetEmployees();
    }
}
