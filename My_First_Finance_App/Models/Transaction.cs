using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My_First_Finance_App.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }


	/*	[ForeignKey("IncomeType")]
		public int? IncomeTypeId { get; set; } // Nullable as not all transactions may be associated with an income type
		public IncomeType IncomeType { get; set; }

		// New property for salary
		public decimal Salary { get; set; }*/
	}
}
