using System.Collections.Generic;

namespace EmployeeManagement.Entities.Interfaces
{
    public interface ISalaryRepository
    {
        void AddSalary(Salary salary);
        void UpdateSalary(int salaryId, Salary salary);
        void RemoveSalary(int salaryId);
        void RemoveSalaryDetailsForEmployee(int employeeId);
        List<Salary> GetSalariesByEmployeeId(int employeeId);
        List<Salary> GetSalaries();
        Salary GetSalaryById(int salaryId);
    }
}
