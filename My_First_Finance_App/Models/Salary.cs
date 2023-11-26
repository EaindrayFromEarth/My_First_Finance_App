using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_First_Finance_App.Models
{
	public class Salary
	{
		[Key]
		public int SalaryId { get; set; }
		public decimal Amount { get; set; }
		public DateTime Timestamp { get; set; }

		[ForeignKey("IncomeSource")] 
		public int IncomeSourceId { get; set; }
		public IncomeSource IncomeSource { get; set; }
	}
}
