using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace My_First_Finance_App.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Replace "YourConnectionStringHere" with your actual connection string
                string connectionString = "Server=.;Database=TestDb;User=sa;Password=sa@123;";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
