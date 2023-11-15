using My_First_Finance_App.Models; // Ensure that you have the correct namespace

namespace My_First_Finance_App.Views.Transaction
{
    public class TDetailsModel
    {
        public int TransactionId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }

        // Additional properties if needed
    }
}
