using ExpenseTrackerApp.Models;
using ExpenseTrackerApp.Repository;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerApp.Services
{
    public class SqlExpenseService : IExpense
    {
        ApplicationContext db;
        public SqlExpenseService(ApplicationContext context) { 
            this.db = context;
        }
        public Expense AddExpense(Expense expense)
        {
            db.ExpenseTB.Add(expense);
            db.SaveChanges();
            return expense;
        }

        public Expense DeleteExpense(int expenceid)
        {
            Expense expense = db.ExpenseTB.Find(expenceid);
            db.ExpenseTB.Remove(expense);
            db.SaveChanges();
            return expense;
        }

        public IEnumerable<Expense> GetAllExpense(int id)
        {
            return db.ExpenseTB.Include(u=>u.User).Where(u=>u.UserID==id);
        }

        public Expense GetExpense(int expenceid)
        {
           return db.ExpenseTB.Include(u=>u.User).FirstOrDefault(u=>u.ExpenseID==expenceid);
        }

        public Expense UpdateExpense(Expense expense)
        {
            db.ExpenseTB.Update(expense);
            db.SaveChanges();
            return expense;
        }
    }
}
