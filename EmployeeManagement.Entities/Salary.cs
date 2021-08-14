using System;

namespace EmployeeManagement.Entities
{
    public class Salary
    {
        public int SalaryId { get; set; }
        public int EmployeeId { get; set; }
        public int SalaryAmount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
