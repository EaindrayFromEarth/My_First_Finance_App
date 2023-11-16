﻿using System.Data.Entity;
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
            return _context.Transactions.Find(transactionId);
        }

        public void AddTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }
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
