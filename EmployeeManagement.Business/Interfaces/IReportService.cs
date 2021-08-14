using AspNetCore.Reporting;

namespace EmployeeManagement.Business.Interfaces
{
    public interface IReportService
    {
        ReportResult GetSummaryReportForEmplpyees();
        ReportResult GetSalaryReportForEmplpyee(int employeeId);
    }
}
