using EmployeeManagement.Entities;
using EmployeeManagement.Entities.Interfaces;
using FluentValidation;
using System;
using System.Linq;

namespace EmployeeManagement.Validator
{
    public class SalaryValidator : AbstractValidator<Salary>, ISalaryValidator
    {
        public const string InvalidEmployeeId = "Employee with EmployeeId does not exists.";
        public const string InvalidSalaryAmount = "Salary amount should be greater than or zero.";

        private readonly IEmployeeRepository _employeeRepository;

        public SalaryValidator(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;

            RuleFor(salary => salary.EmployeeId)
                .Must(ValidateEmployee)
                .WithMessage(InvalidEmployeeId);

            RuleFor(salary => salary.SalaryAmount)
                .GreaterThanOrEqualTo(0)
                .WithMessage(InvalidSalaryAmount);
        }

        public void ValidateSalary(Salary salary)
        {
            var result = Validate(salary);
            if (!result.IsValid)
            {
                throw new InvalidOperationException(
                    string.Join(',', result.Errors.Select(_ => _.ErrorMessage).ToList())
                    );
            }
        }

        private bool ValidateEmployee(int employeeId)
        {
            var employee = _employeeRepository.GetEmployeeById(employeeId);

            return employee == null ? false : true;
        }
    }
}
