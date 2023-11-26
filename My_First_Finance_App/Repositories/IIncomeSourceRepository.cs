using My_First_Finance_App.Models;
using System;
using System.Collections.Generic;

namespace My_First_Finance_App.Repositories
{
	public interface IIncomeSourceRepository
	{
		IEnumerable<IncomeSource> GetAllIncomeSources();
		IncomeSource GetIncomeSourceById(int incomeSourceId);
		void AddIncomeSource(IncomeSource incomeSource);
		void UpdateIncomeSource(IncomeSource incomeSource);
		void DeleteIncomeSource(int incomeSourceId);
	}
}
