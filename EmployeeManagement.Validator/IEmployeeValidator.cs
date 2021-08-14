using EmployeeManagement.Entities;

namespace EmployeeManagement.Validator
{
    public interface IEmployeeValidator
    {
        void ValidateEmployee(Employee employee);
    }
}
