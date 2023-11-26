using My_First_Finance_App.Models;

namespace My_First_Finance_App.Repositories
{
    // ITransactionRepository.cs
    public interface ITransactionRepository
    {
		IEnumerable<Transaction> SearchTransactions(string search);

		IEnumerable<Transaction> GetAllTransactions();
        Transaction GetTransactionById(int transactionId);
        void AddTransaction(Transaction transaction);
        void UpdateTransaction(Transaction transaction);
        void DeleteTransaction(int transactionId);
        IEnumerable<Transaction> GetTransactionsWithAmountGreaterThan(decimal amount);
		IEnumerable<Transaction> GetAllTransactions(int page, int pageSize);
		decimal CalculateSavings(DateTime startDate, DateTime endDate);
       

	}

}
