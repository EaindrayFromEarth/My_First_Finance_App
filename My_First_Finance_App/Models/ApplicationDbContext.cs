using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace My_First_Finance_App.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
		//public DbSet<IncomeType> IncomeTypes { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Replace "YourConnectionStringHere" with your actual connection string
                string connectionString = "Server=.;Database=TestDb;User=sa;Password=sa@123;";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships using Fluent API
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.User)
                .WithMany(u => u.Transactions)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Category)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
        /*        protected override void OnModelCreating(ModelBuilder modelBuilder)
                {
                    modelBuilder.Entity<Transaction>()
                        .HasOne(t => t.User)
                        .WithMany(u => u.Transactions)
                        .HasForeignKey(t => t.UserId);

                    // Add similar configurations for other relationships (e.g., Category)
                }*/

    }
}
