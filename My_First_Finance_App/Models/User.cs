using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace My_First_Finance_App.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        // Other user-related properties
        public List<Transaction> Transactions { get; set; }
		// New property for salary
		//public List<IncomeType> Incomes { get; set; }
	}
}
