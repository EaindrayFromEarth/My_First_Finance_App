using My_First_Finance_App.Models;
using System;
using System.Collections.Generic;

namespace My_First_Finance_App.Repositories
{
	public interface ISalaryRepository
	{
		IEnumerable<Salary> GetAllSalaries();
		Salary GetSalaryById(int salaryId);
		void AddSalary(Salary salary);
		void UpdateSalary(Salary salary);
		void DeleteSalary(int salaryId);
	}
}
