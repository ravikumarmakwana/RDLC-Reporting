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
    public class SalaryService : ISalaryService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ISalaryRepository _salaryRepository;
        private readonly ISalaryValidator _salaryValidator;
        private readonly IMapper _mapper;

        public SalaryService(
            IEmployeeRepository employeeRepository,
            ISalaryRepository salaryRepository,
            ISalaryValidator salaryValidator,
            IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _salaryRepository = salaryRepository;
            _salaryValidator = salaryValidator;
            _mapper = mapper;
        }

        public void AddSalary(SalaryDto salaryDto)
        {
            var salary = _mapper.Map<Salary>(salaryDto);

            _salaryValidator.ValidateSalary(salary);

            _salaryRepository.AddSalary(salary);
        }

        public List<Salary> GetSalaries()
        {
            return _salaryRepository.GetSalaries();
        }

        public List<Salary> GetSalariesByEmployeeId(int employeeId)
        {
            return _salaryRepository.GetSalariesByEmployeeId(employeeId);
        }

        public Salary GetSalaryById(int salaryId)
        {
            return _salaryRepository.GetSalaryById(salaryId);
        }

        public void RemoveSalary(int salaryId)
        {
            ValidateSalary(salaryId);
            _salaryRepository.RemoveSalary(salaryId);
        }

        public void UpdateSalary(int salaryId, SalaryDto salaryDto)
        {
            var salary = _mapper.Map<Salary>(salaryDto);

            _salaryValidator.ValidateSalary(salary);
            ValidateSalary(salaryId);

            _salaryRepository.UpdateSalary(salaryId, salary);
        }

        private void ValidateSalary(int salaryId)
        {
            var salary = _salaryRepository.GetSalaryById(salaryId);

            if (salary == null)
            {
                throw new InvalidOperationException($"Invalid SalaryId {salaryId}");
            }
        }

        private void ValidateEmployee(int employeeId)
        {
            var employee = _employeeRepository.GetEmployeeById(employeeId);

            if (employee == null)
            {
                throw new InvalidOperationException($"Invalid EmployeeId {employeeId}");
            }
        }

        public void RemoveSalaryDetailsForEmployee(int employeeId)
        {
            ValidateEmployee(employeeId);

            _salaryRepository.RemoveSalaryDetailsForEmployee(employeeId);
        }
    }
}
