using ExpenseTrackerApp.Models;

namespace ExpenseTrackerApp.Services
{
    public interface IExpense
    {
        Expense AddExpense(Expense expense);
        Expense UpdateExpense(Expense expense);
        Expense DeleteExpense(int id);
        Expense GetExpense(int id);
        IEnumerable<Expense> GetAllExpense(int id);
    }
}
