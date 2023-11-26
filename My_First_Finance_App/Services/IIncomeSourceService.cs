using My_First_Finance_App.Models;
using System;

namespace My_First_Finance_App.Services
{
	public interface IIncomeSourceService
	{
		IEnumerable<IncomeSource> GetAllIncomeSources();
		IncomeSource GetIncomeSourceById(int incomeSourceId);
		void AddIncomeSource(IncomeSource incomeSource);
		void UpdateIncomeSource(IncomeSource incomeSource);
		void DeleteIncomeSource(int incomeSourceId);
	}
}
