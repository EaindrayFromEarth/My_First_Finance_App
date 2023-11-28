using System;
using Microsoft.EntityFrameworkCore; // Add this line
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using My_First_Finance_App.Models;
namespace My_First_Finance_App.Repositories
{
    // TransactionRepository.cs
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _context;

        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            return _context.Transactions.Include(t => t.User).Include(t => t.Category).ToList();
        }

		public IEnumerable<Transaction> GetAllTransactions(int page, int pageSize)
		{
			// Calculate the number of skipped rows based on the page and pageSize
			int skipRows = (page - 1) * pageSize;

			// Perform pagination using LINQ
			return _context.Transactions
				.Include(t => t.User)
				.Include(t => t.Category)
				.OrderBy(t => t.Amount)  // Adjust the ordering based on your requirements
				.Skip(skipRows)
				.Take(pageSize)
				.ToList();
		}

		public IEnumerable<Transaction> SearchTransactions(string search)
		{
			var transition = _context.Transactions
				.Include(t => t.User)
				.Include(t => t.Category)
				.Where(t =>
					t.User.Username.Contains(search) ||
					t.Category.Name.Contains(search)
				// Add additional search criteria as needed
				)
				.ToList() ;
			return transition;

/*			return _context.Transactions
				.Include(t => t.User)
				.Include(t => t.Category)
				.Where(t =>
					t.User.Username.Contains(search) ||
					t.Category.Name.Contains(search)
				// Add additional search criteria as needed
				)
				.ToList();*/
		}

		public decimal CalculateSavings(DateTime startDate, DateTime endDate)
		{
			var transactions = _context.Transactions
				.Where(t => t.Date >= startDate && t.Date <= endDate)
				.ToList();

			var totalSalaries = transactions.Where(t => t.Salary != null).Sum(t => t.Salary.Amount);
			var totalExpenses = transactions.Where(t => t.Amount < 0).Sum(t => t.Amount);

			return totalSalaries - Math.Abs(totalExpenses);
		}
		public Transaction GetTransactionById(int transactionId)
        {
            return _context.Transactions.Find(transactionId);
        }

		public void AddTransaction(Transaction transaction)
		{
			// Check if the user with the specified UserId exists
			var user = _context.Users.Find(transaction.UserId);
			if (user == null)
			{
				// Handle the case where the user does not exist
				throw new InvalidOperationException("User does not exist.");
			}

			// If Salary is not provided, set a default SalaryId (e.g., 1) or use an existing salary
			if (transaction.Salary == null)
			{
				// Set a default SalaryId (you can change this based on your logic)
				transaction.SalaryId = 1;

				// Alternatively, you can set it to an existing salary
				// transaction.SalaryId = _context.Salaries.FirstOrDefault()?.SalaryId;
			}

			// If the user and SalaryId exist, add the transaction
			_context.Transactions.Add(transaction);
			_context.SaveChanges();
		}


		/*        public void AddTransaction(Transaction transaction)
                {
                    // Check if the user with the specified UserId exists
                    var user = _context.Users.Find(transaction.UserId);
                    if (user == null)
                    {
                        // Handle the case where the user does not exist
                        // You might throw an exception or handle it appropriately
                        throw new InvalidOperationException("User does not exist.");
                    }

                    // If the user exists, add the transaction
                    _context.Transactions.Add(transaction);
                    _context.SaveChanges();
                }*/

		public void UpdateTransaction(Transaction transaction)
		{
			_context.Transactions.Update(transaction);
			_context.SaveChanges();
		}

		/*        public void UpdateTransaction(Transaction transaction)
				{
					_context.Entry(transaction).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
					_context.SaveChanges();
				}*/

		public void DeleteTransaction(int transactionId)
    {
        var transaction = _context.Transactions.Find(transactionId);
        if (transaction != null)
        {
            _context.Transactions.Remove(transaction);
            _context.SaveChanges();
        }
    }

/*        public void UpdateTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }*/

        public IEnumerable<Transaction> GetTransactionsWithAmountGreaterThan(decimal amount)
        {
            throw new NotImplementedException();
        }

		public decimal GetTotalTransactionAmount()
		{
			// Calculate the total transaction amount
			return GetAllTransactions().Sum(t => t.Amount);
		}

	}

}
