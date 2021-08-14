using AspNetCore.Reporting;
using EmployeeManagement.Business.Interfaces;
using EmployeeManagement.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace EmployeeManagement.Business.Implementations
{
    public class ReportService : IReportService
    {
        private readonly ISalaryRepository _salaryRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public ReportService(ISalaryRepository salaryRepository, IEmployeeRepository employeeRepository)
        {
            _salaryRepository = salaryRepository;
            _employeeRepository = employeeRepository;
        }

        public ReportResult GetSalaryReportForEmplpyee(int employeeId)
        {
            var employee = _employeeRepository.GetEmployeeById(employeeId);
            var salaries = _salaryRepository.GetSalariesByEmployeeId(employeeId);

            var parameters = new Dictionary<string, string>();
            parameters.Add("ReportGenerationDateTime", DateTime.Now.ToString("MMMM dd, yyyy hh:mm:ss tt"));
            parameters.Add("EmployeeName", $"{employee.FirstName} {employee.LastName}");
            parameters.Add("DepartmentName", employee.DepartmentName);

            return GetReportResult("SalaryReportForEmployee.rdlc", "DataSet1", salaries, parameters);
        }

        public ReportResult GetSummaryReportForEmplpyees()
        {
            var salaries = _salaryRepository.GetSalaries();

            var parameters = new Dictionary<string, string>();
            parameters.Add("ReportGenerationDateTime", DateTime.Now.ToString("MMMM dd, yyyy hh:mm:ss tt"));

            return GetReportResult("SummaryReport.rdlc", "DataSet1", salaries, parameters);
        }

        private ReportResult GetReportResult(string reportFileName, string dataSetName, object dataSource, Dictionary<string,string> parameters)
        {
            var minType = "";
            int extension = 1;
            var path = $"{Directory.GetCurrentDirectory()}\\..\\EmployeeManagement.Reports\\{reportFileName}";
            var localReport = new LocalReport(path);
            localReport.AddDataSource(dataSetName, dataSource);
            return localReport.Execute(RenderType.Pdf, extension, parameters, minType);
        }
    }
}
