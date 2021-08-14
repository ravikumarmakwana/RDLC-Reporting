using EmployeeManagement.Entities;

namespace EmployeeManagement.Validator
{
    public interface ISalaryValidator
    {
        void ValidateSalary(Salary salary);
    }
}
