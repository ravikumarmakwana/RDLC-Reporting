using System;
using System.Collections.Generic;
using static EmployeeManagement.Core.EmployeeManagementEnums;

namespace EmployeeManagement.Entities
{
    public class Employee
    {
        public Employee()
        {
            Salaries = new List<Salary>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DepartmentName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }

        public List<Salary> Salaries { get; set; }
    }
}
