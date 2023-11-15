using System.ComponentModel.DataAnnotations;


namespace My_First_Finance_App.Models
{
    public class Transaction
    {
        [Key] 
        public int TransactionId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        // Other transaction-related properties
        public int UserId { get; set; }
        public User User { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
