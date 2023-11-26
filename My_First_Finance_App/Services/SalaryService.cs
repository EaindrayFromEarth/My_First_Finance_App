using System;
using System.Collections.Generic;
using My_First_Finance_App.Models;
using My_First_Finance_App.Repositories;

namespace My_First_Finance_App.Services
{
    public class SalaryService : ISalaryService
    {
        private readonly ISalaryRepository _salaryRepository;

        public SalaryService(ISalaryRepository salaryRepository)
        {
            _salaryRepository = salaryRepository;
        }

        public IEnumerable<Salary> GetAllSalaries()
        {
            return _salaryRepository.GetAllSalaries();
        }

        public Salary GetSalaryById(int salaryId)
        {
            return _salaryRepository.GetSalaryById(salaryId);
        }

        public void AddSalary(Salary salary)
        {
            _salaryRepository.AddSalary(salary);
        }

        public void UpdateSalary(Salary salary)
        {
            _salaryRepository.UpdateSalary(salary);
        }

        public void DeleteSalary(int salaryId)
        {
            _salaryRepository.DeleteSalary(salaryId);
        }
    }
}
