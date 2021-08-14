using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public class EmployeeDisplayDto
    {
        public EmployeeDisplayDto()
        {
            Salaries = new List<SalaryDto>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DepartmentName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        public List<SalaryDto> Salaries { get; set; }
    }
}
