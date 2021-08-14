using AutoMapper;
using EmployeeManagement.Core;
using EmployeeManagement.Entities;
using EmployeeManagement.Models;
using System;
using static EmployeeManagement.Core.EmployeeManagementEnums;

namespace EmployeeManagement.Business.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeDto, Employee>()
                .ForMember(dest => dest.Gender,
                opt => opt.MapFrom(
                    src => src != null ? Enum.Parse<Gender>(src.Gender) : Gender.Not_Defined
                    )
                );

            CreateMap<Employee, EmployeeDisplayDto>()
                .ForMember(dest => dest.Age,
                opt => opt.MapFrom(
                    src => src.BirthDate.CalculateAge()
                    )
                );
        }
    }
}
