using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using My_First_Finance_App.Models;

namespace My_First_Finance_App.Repositories
{
	public class IncomeSourceRepository : IIncomeSourceRepository
	{
		private readonly ApplicationDbContext _context;

		public IncomeSourceRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public IEnumerable<IncomeSource> GetAllIncomeSources()
		{
			return _context.IncomeSources.Include(i => i.Salaries).ToList();
		}

		public IncomeSource GetIncomeSourceById(int incomeSourceId)
		{
			return _context.IncomeSources.Find(incomeSourceId);
		}

		public void AddIncomeSource(IncomeSource incomeSource)
		{
			_context.IncomeSources.Add(incomeSource);
			_context.SaveChanges();
		}

		public void UpdateIncomeSource(IncomeSource incomeSource)
		{
			_context.IncomeSources.Update(incomeSource);
			_context.SaveChanges();
		}

		public void DeleteIncomeSource(int incomeSourceId)
		{
			var incomeSource = _context.IncomeSources.Find(incomeSourceId);
			if (incomeSource != null)
			{
				_context.IncomeSources.Remove(incomeSource);
				_context.SaveChanges();
			}
		}
	}
}
