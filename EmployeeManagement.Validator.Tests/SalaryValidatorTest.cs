using EmployeeManagement.Entities;
using EmployeeManagement.Entities.Interfaces;
using FluentValidation.TestHelper;
using Moq;
using Xunit;

namespace EmployeeManagement.Validator.Tests
{
    public class SalaryValidatorTest
    {
        private readonly SalaryValidator _salaryvalidator;
        private readonly Mock<IEmployeeRepository> _employeeRepository;

        public SalaryValidatorTest()
        {
            _employeeRepository = new Mock<IEmployeeRepository>();
            _salaryvalidator = new SalaryValidator(_employeeRepository.Object);
        }

        [Fact]
        public void SalaryValidator_ValidEmployeeId_ShouldPass()
        {
            var employeeId = 1;
            var employee = new Employee { EmployeeId = employeeId };
            var salary = new Salary { EmployeeId = employeeId };

            _employeeRepository.Setup(_ => _.GetEmployeeById(employeeId))
                .Returns(employee);

            var result = _salaryvalidator.TestValidate(salary);

            result.ShouldNotHaveValidationErrorFor(salary => salary.EmployeeId);
        }

        [Fact]
        public void SalaryValidator_InvalidEmployeeId_ShouldFail()
        {
            var employeeId = 1;
            var salary = new Salary { EmployeeId = employeeId };

            _employeeRepository.Setup(_ => _.GetEmployeeById(employeeId))
                .Returns(() => null);

            var result = _salaryvalidator.TestValidate(salary);

            result.ShouldHaveValidationErrorFor(salary => salary.EmployeeId)
                .WithErrorMessage(SalaryValidator.InvalidEmployeeId);
        }

        [Fact]
        public void SalaryValidator_SalaryAmountGreaterThanZero_ShouldPass()
        {
            var salary = new Salary { SalaryAmount = 10000 };
            var result = _salaryvalidator.TestValidate(salary);

            result.ShouldNotHaveValidationErrorFor(salary => salary.SalaryAmount);
        }

        [Fact]
        public void SalaryValidator_SalaryAmountEqualToZero_ShouldPass()
        {
            var salary = new Salary { SalaryAmount = 0 };
            var result = _salaryvalidator.TestValidate(salary);

            result.ShouldNotHaveValidationErrorFor(salary => salary.SalaryAmount);
        }

        [Fact]
        public void SalaryValidator_SalaryAmountLessThanZero_ShouldFail()
        {
            var salary = new Salary { SalaryAmount = -10000 };
            var result = _salaryvalidator.TestValidate(salary);

            result.ShouldHaveValidationErrorFor(salary => salary.SalaryAmount)
                .WithErrorMessage(SalaryValidator.InvalidSalaryAmount);
        }
    }
}
