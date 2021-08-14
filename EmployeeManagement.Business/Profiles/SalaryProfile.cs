using AutoMapper;
using EmployeeManagement.Entities;
using EmployeeManagement.Models;

namespace EmployeeManagement.Business.Profiles
{
    public class SalaryProfile : Profile
    {
        public SalaryProfile()
        {
            CreateMap<SalaryDto, Salary>();
        }
    }
}
