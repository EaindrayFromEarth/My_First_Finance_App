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
        public Transaction GetTransactionById(int transactionId)
        {
            return _context.Transactions.Include(t => t.User).Include(t => t.Category)
                .FirstOrDefault(t => t.TransactionId == transactionId);
        }


        /*        public Transaction GetTransactionById(int transactionId)
                {
                    return _context.Transactions.Find(transactionId);
                }*/

        public void AddTransaction(Transaction transaction)
        {
            // Check if the user exists
            var userExists = _context.Users.Any(u => u.UserId == transaction.UserId);

            if (!userExists)
            {
                // Handle the scenario where the user doesn't exist
                throw new InvalidOperationException("User does not exist.");
            }

            // If the user exists, proceed to add the transaction
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
            _context.Entry(transaction).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
            _context.SaveChanges();
        }

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

        /*        public IEnumerable<Transaction> GetTransactionsWithAmountGreaterThan(decimal amount)
                {
                    var sql = "SELECT * FROM Transactions WHERE Amount > @amount";
                    return _context.Database.SqlQuery<Transaction>(sql, new SqlParameter("@amount", amount)).ToList();

                }*/
    }

}
