using Microsoft.EntityFrameworkCore;
using ExpenseTrackerApp.Models;

namespace ExpenseTrackerApp.Repository
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>().ToTable(tb => tb.HasTrigger("tr_ExpenseInserted"));
            //modelBuilder.Entity<Expense>().ToTable(tb => tb.HasTrigger("tr_ExpenseDeleted"));
            //modelBuilder.Entity<Expense>().ToTable(tb => tb.HasTrigger("tr_ExpenseUpdated"));
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.User)
                .WithMany().OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Expense>()
                .HasOne(t => t.User)
                .WithMany().OnDelete(DeleteBehavior.NoAction);
        }
        public DbSet<User> UserTB { get; set; }
        public DbSet<Expense> ExpenseTB { get; set; }
        public DbSet<Budget> BudgetsTB { get; set;}
        public DbSet<Transaction> TransactionTB { get; set; }
    }
}
