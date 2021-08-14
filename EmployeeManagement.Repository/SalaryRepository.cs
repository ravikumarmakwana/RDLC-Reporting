using EmployeeManagement.Entities;
using EmployeeManagement.Entities.Interfaces;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace EmployeeManagement.Repository
{
    public class SalaryRepository : BaseRepository, ISalaryRepository
    {
        public SalaryRepository(IOptions<DbConfiguration> options)
            : base(options) { }

        public void AddSalary(Salary salary)
        {
            ExecuteMySql(
                "INSERT INTO Salary (EmployeeId, SalaryAmount) " +
                "VALUES " +
                "(@EmployeeId, @SalaryAmount);",
                new
                {
                    EmployeeId = salary.EmployeeId,
                    SalaryAmount = salary.SalaryAmount
                });
        }

        public List<Salary> GetSalaries()
        {
            return ExecuteMySqlReturnList<Salary>(
                "SELECT * FROM Salary;",
                new { }
                );
        }

        public List<Salary> GetSalariesByEmployeeId(int employeeId)
        {
            return ExecuteMySqlReturnList<Salary>(
                "SELECT * FROM Salary WHERE EmployeeId = @EmployeeId;",
                new
                {
                    EmployeeId = employeeId
                });
        }

        public Salary GetSalaryById(int salaryId)
        {
            return ExecuteMySqlReturnFirst<Salary>(
                "SELECT * FROM Salary WHERE SalaryId = @SalaryId;",
                new
                {
                    SalaryId = salaryId
                });
        }

        public void RemoveSalary(int salaryId)
        {
            ExecuteMySql(
                "DELETE FROM Salary WHERE SalaryId = @SalaryId;",
                new
                {
                    SalaryId = salaryId
                }
                );
        }

        public void RemoveSalaryDetailsForEmployee(int employeeId)
        {
            ExecuteMySql(
                "DELETE FROM Salary WHERE EmployeeId = @EmployeeId;",
                new
                {
                    EmployeeId = employeeId
                }
                );
        }

        public void UpdateSalary(int salaryId, Salary salary)
        {
            ExecuteMySql(
                "UPDATE Salary " +
                "SET " +
                "SalaryAmount = @SalaryAmount " +
                "WHERE SalaryId = @SalaryId;",
                new
                {
                    SalaryId = salaryId,
                    SalaryAmount = salary.SalaryAmount
                });
        }
    }
}
