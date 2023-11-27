using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using My_First_Finance_App.Models;

namespace My_First_Finance_App.Repositories
{
	public class SalaryRepository : ISalaryRepository
	{
		private readonly ApplicationDbContext _context;
		private readonly TransactionRepository _transactionRepository;

		public SalaryRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public IEnumerable<Salary> GetAllSalaries()
		{
			return _context.Salaries.Include(s => s.IncomeSource).ToList();
		}

		public Salary GetSalaryById(int salaryId)
		{
			return _context.Salaries.Find(salaryId);
		}

		public void AddSalary(Salary salary)
		{
			_context.Salaries.Add(salary);
			_context.SaveChanges();
		}

		public void UpdateSalary(Salary salary)
		{
			_context.Salaries.Update(salary);
			_context.SaveChanges();
		}

		public void DeleteSalary(int salaryId)
		{
			var salary = _context.Salaries.Find(salaryId);
			if (salary != null)
			{
				_context.Salaries.Remove(salary);
				_context.SaveChanges();
			}
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
