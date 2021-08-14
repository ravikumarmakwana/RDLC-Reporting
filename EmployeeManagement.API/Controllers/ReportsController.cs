using EmployeeManagement.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [Route("reports/employees")]
    public class ReportsController : BaseController
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        public IActionResult GetSalarySummaryReport()
        {
            return File(
                _reportService.GetSummaryReportForEmplpyees().MainStream,
                "application/pdf"
                );
        }

        [HttpGet("{employeeId}")]
        public IActionResult GetEmployeeSalaryReport(int employeeId)
        {
            return File(
                _reportService.GetSalaryReportForEmplpyee(employeeId).MainStream,
                "application/pdf"
                );
        }
    }
}