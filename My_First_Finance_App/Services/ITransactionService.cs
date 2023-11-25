using My_First_Finance_App.Models;

namespace My_First_Finance_App.Services
{
    public interface ITransactionService
    {
		IEnumerable<Transaction> SearchTransactions(string search);

		IEnumerable<Transaction> GetAllTransactions();
        Transaction GetTransactionById(int transactionId);
        void AddTransaction(Transaction transaction);
        void UpdateTransaction(Transaction transaction);
        void DeleteTransaction(int transactionId);
	}
}
