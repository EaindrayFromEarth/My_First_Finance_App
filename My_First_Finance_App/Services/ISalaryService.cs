using My_First_Finance_App.Models;
using System;

namespace My_First_Finance_App.Services
{
	public interface ISalaryService
	{
		IEnumerable<Salary> GetAllSalaries();
		Salary GetSalaryById(int salaryId);
		void AddSalary(Salary salary);
		void UpdateSalary(Salary salary);
		void DeleteSalary(int salaryId);

		decimal AddAllSalary();
	}
}
