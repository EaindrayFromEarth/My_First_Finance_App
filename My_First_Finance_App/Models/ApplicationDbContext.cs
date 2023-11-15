using System.Collections.Generic;
using System.Data.Entity;

namespace My_First_Finance_App.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure your database connection
            optionsBuilder.UseSqlServer("YourConnectionStringHere");
        }
    }
}
