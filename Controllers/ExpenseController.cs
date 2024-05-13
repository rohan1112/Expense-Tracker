using Microsoft.AspNetCore.Mvc;
using ExpenseTrackerApp.Models;
using ExpenseTrackerApp.Services;

namespace ExpenseTrackerApp.Controllers
{
    [Route("User/[controller]/[action]")]
    public class ExpenseController : Controller
    {
        IExpense service;
        IBudget budget;
        public ExpenseController(IExpense service,IBudget budget) {
            this.service = service;
            this.budget = budget;
        }
        public IActionResult Index(int id)
        {
            if (id == 0 || id==null)
            {
                return RedirectToAction("Login","User");
            }
            var AllExpense = service.GetAllExpense(id);
            return View(AllExpense);
        }

        public IActionResult Create() {
           if (HttpContext.Session.GetString("Email") != null)
            {
                ViewBag.id = HttpContext.Session.GetInt32("userId");
                return View();
            }
            return RedirectToAction("Login","User");
        }
        [HttpPost]
        public IActionResult Create(Expense ex)
        {
            Budget b = budget.GetBudgetByUserandCategory(ex.UserID, ex.Category);
            if (b == null)
            {
                return RedirectToAction("Create", "Budget");
            }
            if (b.Amount > ex.Amount)
            {
                ex.RemainingAmount=b.Amount-ex.Amount;
                budget.UpdateBudgetAmount(b.BudgetID,b.Amount - ex.Amount);
            }
            else
            {
                return RedirectToAction("Error", "User",new { message = "Budget is not define or amount is greater than budget" });
            }
            Expense e =service.AddExpense(ex);
            return RedirectToAction(nameof(Index), new {id=e.UserID});
        }

        public IActionResult Edit(int id)
        {
            Expense expense = service.GetExpense(id);
            ViewBag.UserId = expense.UserID;
            return View(expense);
        }
        [HttpPost]
        public IActionResult Edit(Expense ex)
        {
            Expense e=service.UpdateExpense(ex);
            return RedirectToAction(nameof(Index), new {id=e.UserID});
        }

        public IActionResult Delete(int id)
        {
            Expense expense = service.GetExpense(id);
            return View(expense);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteExpense(int expenseId)
        {
            Expense e=service.DeleteExpense(expenseId);
            return RedirectToAction(nameof(Index),new {id=e.UserID});
        }


        public IActionResult Details(int id)
        {
            Expense expense = service.GetExpense(id);
            return View(expense);
        }

    }
}
