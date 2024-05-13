using ExpenseTrackerApp.Models;

namespace ExpenseTrackerApp.Services
{
    public interface IBudget
    {
        IEnumerable<Budget> GetAllBudgetsByUser(int? id);
        Budget GetBudget(int budgetId);

        Budget AddBudget (Budget budget);
        Budget UpdateBudget (Budget budget);
        Budget DeleteBudget (int budgetId);
        Budget UpdateBudgetAmount(int id,decimal Amount);

        Budget GetBudgetByUserandCategory(int UserId, string Category);
    }
}
