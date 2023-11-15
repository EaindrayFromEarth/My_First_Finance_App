using My_First_Finance_App.Models;

namespace My_First_Finance_App.Repositories
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> GetAllTransactions();
        Transaction GetTransactionById(int transactionId);
        void AddTransaction(Transaction transaction);
        void UpdateTransaction(Transaction transaction);
        void DeleteTransaction(int transactionId);
    }
}
