using EmployeeManagement.Entities;
using FluentValidation;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace EmployeeManagement.Validator
{
    public class EmployeeValidator : AbstractValidator<Employee>, IEmployeeValidator
    {
        public const string FirstNameRequired = "First name is required.";
        public const string LastNameRequired = "Last name is required.";
        public const string DepartmentNameRequired = "Department is required.";
        public const string EmailAddressRequired = "Email address is required.";
        public const string InvalidEmailAddress = "Please enter valid email address.";
        public const string BirthDateRequired = "Birth date is required.";

        public EmployeeValidator()
        {
            RuleFor(employee => employee.FirstName)
                .NotEmpty()
                .WithMessage(FirstNameRequired);

            RuleFor(employee => employee.LastName)
                .NotEmpty()
                .WithMessage(LastNameRequired);

            RuleFor(employee => employee.DepartmentName)
                .NotEmpty()
                .WithMessage(DepartmentNameRequired);

            RuleFor(employee => employee.EmailAddress)
                .NotEmpty()
                .WithMessage(EmailAddressRequired)
                .Must(emailAddresss => emailAddresss != null && IsValidEmailAddress(emailAddresss))
                .WithMessage(InvalidEmailAddress);

            RuleFor(employee => employee.BirthDate)
                .NotEmpty()
                .WithMessage(BirthDateRequired);
        }

        public void ValidateEmployee(Employee employee)
        {
            var result = Validate(employee);
            if (!result.IsValid)
            {
                throw new InvalidOperationException(
                    string.Join('\n', result.Errors.Select(_ => _.ErrorMessage).ToList())
                    );
            }
        }

        private bool IsValidEmailAddress(string emailAddress)
        {
            return Regex
                .IsMatch(
                    emailAddress,
                    @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                    RegexOptions.IgnoreCase
                    );
        }
    }
}
