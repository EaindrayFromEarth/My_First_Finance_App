using System;
using System.Collections.Generic;
using My_First_Finance_App.Models;
using My_First_Finance_App.Repositories;

namespace My_First_Finance_App.Services
{
    public class SalaryService : ISalaryService
    {
    private readonly ISalaryRepository _salaryRepository;
    private readonly ITransactionService _transactionService;
		private readonly TransactionRepository _transactionRepository;
		private readonly ITransactionRepository _itransactionRepository;

		public SalaryService(ISalaryRepository salaryRepository,
            ITransactionService transactionService,
            TransactionRepository transactionRepository,
			 ITransactionRepository itransactionRepository)
    {
        _salaryRepository = salaryRepository;
        _transactionService = transactionService;
			_transactionRepository = transactionRepository;
			_itransactionRepository = itransactionRepository;
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

		public decimal AddAllSalary()
		{
			// Calculate the total balance by summing up all salaries
			decimal totalSalary = GetAllSalaries().Sum(s => s.Amount);

			// Subtract total transaction amount to get the net balance
			decimal totalTransactionAmount = _transactionRepository.GetTotalTransactionAmount();
			decimal netBalance = totalSalary - totalTransactionAmount;

			return netBalance;
		}

	}
}
