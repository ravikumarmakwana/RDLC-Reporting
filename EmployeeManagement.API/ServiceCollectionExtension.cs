using EmployeeManagement.Business.Implementations;
using EmployeeManagement.Business.Interfaces;
using EmployeeManagement.Entities.Interfaces;
using EmployeeManagement.Repository;
using EmployeeManagement.Validator;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.API
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ISalaryService, SalaryService>();
            services.AddScoped<IReportService, ReportService>();
            
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ISalaryRepository, SalaryRepository>();

            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeValidator, EmployeeValidator>();
            services.AddScoped<ISalaryValidator, SalaryValidator>();

            return services;
        }
    }
}
