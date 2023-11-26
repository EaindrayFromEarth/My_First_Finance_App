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


		[ForeignKey("Salary")]
		public int? SalaryId { get; set; }
		public Salary? Salary { get; set; }


		public decimal SavingBalance { get; set; }


        // Add these properties
        [NotMapped] // This ensures that these properties are not mapped to the database
        public string Username => User?.Username;

        [NotMapped]
        public string CategoryName => Category?.Name;
        /*	[ForeignKey("IncomeType")]
			public int? IncomeTypeId { get; set; } // Nullable as not all transactions may be associated with an income type
			public IncomeType IncomeType { get; set; }

			// New property for salary
			public decimal Salary { get; set; }*/
    }
}
