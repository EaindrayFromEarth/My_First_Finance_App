using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using My_First_Finance_App.Models;

namespace My_First_Finance_App.Repositories
{
	public class SalaryRepository : ISalaryRepository
	{
		private readonly ApplicationDbContext _context;

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
	}
}
