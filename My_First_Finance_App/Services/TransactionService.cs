using My_First_Finance_App.Models;
using My_First_Finance_App.Repositories;

namespace My_First_Finance_App.Services
{
	public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

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
	}

}
