using System;
using System.Collections.Generic;
using My_First_Finance_App.Models;
using My_First_Finance_App.Repositories;

namespace My_First_Finance_App.Services
{
	public class IncomeSourceService : IIncomeSourceService
	{
		private readonly IIncomeSourceRepository _incomeSourceRepository;

		public IncomeSourceService(IIncomeSourceRepository incomeSourceRepository)
		{
			_incomeSourceRepository = incomeSourceRepository;
		}

		public IEnumerable<IncomeSource> GetAllIncomeSources()
		{
			return _incomeSourceRepository.GetAllIncomeSources();
		}

		public IncomeSource GetIncomeSourceById(int incomeSourceId)
		{
			return _incomeSourceRepository.GetIncomeSourceById(incomeSourceId);
		}

		public void AddIncomeSource(IncomeSource incomeSource)
		{
			_incomeSourceRepository.AddIncomeSource(incomeSource);
		}

		public void UpdateIncomeSource(IncomeSource incomeSource)
		{
			_incomeSourceRepository.UpdateIncomeSource(incomeSource);
		}

		public void DeleteIncomeSource(int incomeSourceId)
		{
			_incomeSourceRepository.DeleteIncomeSource(incomeSourceId);
		}
	}
}
