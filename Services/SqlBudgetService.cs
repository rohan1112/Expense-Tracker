using ExpenseTrackerApp.Models;
using ExpenseTrackerApp.Repository;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerApp.Services
{
    public class SqlBudgetService : IBudget
    {
        ApplicationContext db;
        public SqlBudgetService(ApplicationContext context) { 
            this.db = context;
        }
        public Budget AddBudget(Budget budget)
        {
            db.BudgetsTB.Add(budget);
            db.SaveChanges();
            return budget;
        }

        public Budget DeleteBudget(int budgetId)
        {
            var budget=db.BudgetsTB.FirstOrDefault(u => u.BudgetID == budgetId);
            db.BudgetsTB.Remove(budget);
            db.SaveChanges();
            return budget;
        }

        public IEnumerable<Budget> GetAllBudgetsByUser(int? id)
        {
            return db.BudgetsTB.Include(u=>u.User).Where(u => u.UserID == id);
        }

        public Budget GetBudget(int budgetId)
        {
            return db.BudgetsTB.FirstOrDefault(u => u.BudgetID == budgetId);
        }

        public Budget GetBudgetByUserandCategory(int UserId, string Category)
        {
            return db.BudgetsTB.FirstOrDefault(b => b.UserID == UserId && b.Category == Category);
        }

        public Budget UpdateBudget(Budget budget)
        {
            db.BudgetsTB.Update(budget);
            db.SaveChanges();
            return budget;
        }

        public Budget UpdateBudgetAmount(int id,decimal Amount)
        {
            var b=db.BudgetsTB.Find(id);
            b.Amount = Amount;
            db.SaveChanges();
            return db.BudgetsTB.Find(id);
        }
    }
}
