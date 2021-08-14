using EmployeeManagement.Entities;
using FluentValidation.TestHelper;
using System;
using Xunit;

namespace EmployeeManagement.Validator.Tests
{
    public class EmployeeValidatorTest
    {
        private readonly EmployeeValidator _employeeValidator;

        public EmployeeValidatorTest()
        {
            _employeeValidator = new EmployeeValidator();
        }

        [Fact]
        public void EmployeeValidator_ValidFirstName_ShouldPass()
        {
            var employee = new Employee { FirstName = "Test" };
            var result = _employeeValidator.TestValidate(employee);

            result.ShouldNotHaveValidationErrorFor(employee => employee.FirstName);
        }

        [Fact]
        public void EmployeeValidator_EmptyFirstName_ShouldFail()
        {
            var employee = new Employee { FirstName = string.Empty };
            var result = _employeeValidator.TestValidate(employee);

            result.ShouldHaveValidationErrorFor(employee => employee.FirstName)
                .WithErrorMessage(EmployeeValidator.FirstNameRequired);
        }

        [Fact]
        public void EmployeeValidator_NullFirstName_ShouldFail()
        {
            var employee = new Employee { FirstName = null };
            var result = _employeeValidator.TestValidate(employee);

            result.ShouldHaveValidationErrorFor(employee => employee.FirstName)
                .WithErrorMessage(EmployeeValidator.FirstNameRequired);
        }

        [Fact]
        public void EmployeeValidator_ValidLastName_ShouldPass()
        {
            var employee = new Employee { LastName = "Test" };
            var result = _employeeValidator.TestValidate(employee);

            result.ShouldNotHaveValidationErrorFor(employee => employee.LastName);
        }

        [Fact]
        public void EmployeeValidator_EmptyLastName_ShouldFail()
        {
            var employee = new Employee { LastName = string.Empty };
            var result = _employeeValidator.TestValidate(employee);

            result.ShouldHaveValidationErrorFor(employee => employee.LastName)
                .WithErrorMessage(EmployeeValidator.LastNameRequired);
        }

        [Fact]
        public void EmployeeValidator_NullLastName_ShouldFail()
        {
            var employee = new Employee { LastName = null };
            var result = _employeeValidator.TestValidate(employee);

            result.ShouldHaveValidationErrorFor(employee => employee.LastName)
                .WithErrorMessage(EmployeeValidator.LastNameRequired);
        }

        [Fact]
        public void EmployeeValidator_ValidDepartmentName_ShouldPass()
        {
            var employee = new Employee { DepartmentName = "Test" };
            var result = _employeeValidator.TestValidate(employee);

            result.ShouldNotHaveValidationErrorFor(employee => employee.DepartmentName);
        }

        [Fact]
        public void EmployeeValidator_EmptyDepartmentName_ShouldFail()
        {
            var employee = new Employee { DepartmentName = string.Empty };
            var result = _employeeValidator.TestValidate(employee);

            result.ShouldHaveValidationErrorFor(employee => employee.DepartmentName)
                .WithErrorMessage(EmployeeValidator.DepartmentNameRequired);
        }

        [Fact]
        public void EmployeeValidator_NullDepartmentName_ShouldFail()
        {
            var employee = new Employee { DepartmentName = null };
            var result = _employeeValidator.TestValidate(employee);

            result.ShouldHaveValidationErrorFor(employee => employee.DepartmentName)
                .WithErrorMessage(EmployeeValidator.DepartmentNameRequired);
        }

        [Fact]
        public void EmployeeValidator_ValidEmailAddress_ShouldPass()
        {
            var employee = new Employee { EmailAddress = "test.test@test.test" };
            var result = _employeeValidator.TestValidate(employee);

            result.ShouldNotHaveValidationErrorFor(employee => employee.EmailAddress);
        }

        [Fact]
        public void EmployeeValidator_InValidEmailAddress_ShouldFail()
        {
            var employee = new Employee { EmailAddress = "test.test@" };
            var result = _employeeValidator.TestValidate(employee);

            result.ShouldHaveValidationErrorFor(employee => employee.EmailAddress)
                .WithErrorMessage(EmployeeValidator.InvalidEmailAddress);
        }

        [Fact]
        public void EmployeeValidator_EmptyEmailAddress_ShouldFail()
        {
            var employee = new Employee { EmailAddress = string.Empty };
            var result = _employeeValidator.TestValidate(employee);

            result.ShouldHaveValidationErrorFor(employee => employee.EmailAddress)
                .WithErrorMessage(EmployeeValidator.EmailAddressRequired);
        }

        [Fact]
        public void EmployeeValidator_NullEmailAddress_ShouldFail()
        {
            var employee = new Employee { EmailAddress = null };
            var result = _employeeValidator.TestValidate(employee);

            result.ShouldHaveValidationErrorFor(employee => employee.EmailAddress)
                .WithErrorMessage(EmployeeValidator.EmailAddressRequired);
        }

        [Fact]
        public void EmployeeValidator_ValidBirthDate_ShouldPass()
        {
            var employee = new Employee { BirthDate = DateTime.Parse("2020-04-18") };
            var result = _employeeValidator.TestValidate(employee);

            result.ShouldNotHaveValidationErrorFor(employee => employee.BirthDate);
        }

        [Fact]
        public void EmployeeValidator_EmptyBirthDate_ShouldFail()
        {
            var employee = new Employee();
            var result = _employeeValidator.TestValidate(employee);

            result.ShouldHaveValidationErrorFor(employee => employee.BirthDate)
                .WithErrorMessage(EmployeeValidator.BirthDateRequired);
        }
    }
}
