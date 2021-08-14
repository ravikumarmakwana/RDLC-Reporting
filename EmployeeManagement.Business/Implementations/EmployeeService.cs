using AutoMapper;
using EmployeeManagement.Business.Interfaces;
using EmployeeManagement.Entities;
using EmployeeManagement.Entities.Interfaces;
using EmployeeManagement.Models;
using EmployeeManagement.Validator;
using System;
using System.Collections.Generic;

namespace EmployeeManagement.Business.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeValidator _employeeValidator;
        private readonly IMapper _mapper;

        public EmployeeService(
            IEmployeeRepository employeeRepository,
            IEmployeeValidator employeeValidator,
            IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _employeeValidator = employeeValidator;
            _mapper = mapper;
        }

        public void AddEmployee(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);

            _employeeValidator.ValidateEmployee(employee);
            _employeeRepository.AddEmployee(employee);
        }

        public EmployeeDisplayDto GetEmployeeById(int employeeId)
        {
            return _mapper.Map<EmployeeDisplayDto>(_employeeRepository.GetEmployeeById(employeeId));
        }

        public List<EmployeeDisplayDto> GetEmployees()
        {
            return _mapper.Map<List<EmployeeDisplayDto>>(_employeeRepository.GetEmployees());
        }

        public void RemoveEmployee(int employeeId)
        {
            ValidateEmployee(employeeId);
            _employeeRepository.RemoveEmployee(employeeId);
        }

        public void UpdateEmployee(int employeeId, EmployeeDto employeeDto)
        {
            ValidateEmployee(employeeId);

            var employee = _mapper.Map<Employee>(employeeDto);
            _employeeValidator.ValidateEmployee(employee);
            
            _employeeRepository.UpdateEmployee(employeeId, employee);
        }

        private void ValidateEmployee(int employeeId)
        {
            var employee = _employeeRepository.GetEmployeeById(employeeId);
            if (employee == null)
            {
                throw new InvalidOperationException($"Invalid EmployeeId {employeeId}.");
            }
        }
    }
}
