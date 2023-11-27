using My_First_Finance_App.Models;
using My_First_Finance_App.Repositories;

namespace My_First_Finance_App.Services
{
	public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
       // private readonly IUserService _userService;  // Add this

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
            
        }

        public IEnumerable<Transaction> SearchTransactions(string search)
		{
			// Call the repository method for searching transactions
			return _transactionRepository.SearchTransactions(search);
		}

 
		public IEnumerable<Transaction> GetAllTransactions()
        {
            return _transactionRepository.GetAllTransactions();
        }

        public Transaction GetTransactionById(int transactionId)
        {
            return _transactionRepository.GetTransactionById(transactionId);
        }

        public void AddTransaction(Transaction transaction)
        {
            _transactionRepository.AddTransaction(transaction);
        }

        public void UpdateTransaction(Transaction transaction)
        {
            _transactionRepository.UpdateTransaction(transaction);
        }

        public void DeleteTransaction(int transactionId)
        {
            _transactionRepository.DeleteTransaction(transactionId);
        }

		public IEnumerable<Transaction> GetAllTransactions(int page, int pageSize)
		{
			return _transactionRepository.GetAllTransactions(page, pageSize);
		}

		public decimal CalculateSavings(DateTime startDate, DateTime endDate)
		{
			return _transactionRepository.CalculateSavings(startDate, endDate);
		}
		public decimal GetTotalTransactionAmount()
		{
			// Calculate the total transaction amount
			return GetAllTransactions().Sum(t => t.Amount);
		}

		public IEnumerable<Transaction> FilterTransactions(int selectedMonth, int selectedYear)
		{
			var allTransactions = _transactionRepository.GetAllTransactions();

			// Filter transactions based on selected month and year
			var filteredTransactions = allTransactions
				.Where(t => t.Date.Month == selectedMonth && t.Date.Year == selectedYear)
				.ToList();

			return filteredTransactions;
		}
	}

}
