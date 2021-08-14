using EmployeeManagement.Entities;
using EmployeeManagement.Entities.Interfaces;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace EmployeeManagement.Repository
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public EmployeeRepository(IOptions<DbConfiguration> options)
            : base(options) { }

        public void AddEmployee(Employee employee)
        {
            ExecuteMySql(
                "INSERT INTO Employee (FirstName, LastName, DepartmentName, EmailAddress, PhoneNumber, BirthDate, Gender) " +
                "VALUES " +
                "(@FirstName, @LastName, @DepartmentName, @EmailAddress, @PhoneNumber, @BirthDate, @Gender);",
                new
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    DepartmentName = employee.DepartmentName,
                    EmailAddress = employee.EmailAddress,
                    PhoneNumber = employee.PhoneNumber,
                    BirthDate = employee.BirthDate.Date,
                    Gender = employee.Gender
                });
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return ExecuteMySqlReturnFirst<Employee>(
                "SELECT * FROM Employee WHERE EmployeeId = @EmployeeId;",
                new
                {
                    EmployeeId = employeeId
                }
                );
        }

        public List<Employee> GetEmployees()
        {
            return ExecuteMySqlReturnList<Employee>(
                "SELECT * FROM Employee;",
                new { }
                );
        }

        public void RemoveEmployee(int employeeId)
        {
            ExecuteMySql(
                "DELETE FROM Employee WHERE EmployeeId = @EmployeeId",
                new
                {
                    EmployeeId = employeeId
                }
                );
        }

        public void UpdateEmployee(int employeeId, Employee employee)
        {
            ExecuteMySql(
                "UPDATE Employee " +
                "SET " +
                "FirstName = @FirstName, " +
                "LastName = @LastName, " +
                "DepartmentName = @DepartmentName, " +
                "EmailAddress = @EmailAddress, " +
                "PhoneNumber = @PhoneNumber, " +
                "BirthDate = @BirthDate, " +
                "Gender = @Gender " +
                "WHERE EmployeeId = @EmployeeId;",
                new
                {
                    EmployeeId = employeeId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    DepartmentName = employee.DepartmentName,
                    EmailAddress = employee.EmailAddress,
                    PhoneNumber = employee.PhoneNumber,
                    BirthDate = employee.BirthDate.Date,
                    Gender = employee.Gender
                });
        }
    }
}
