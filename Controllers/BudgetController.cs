using ExpenseTrackerApp.Models;
using ExpenseTrackerApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerApp.Controllers
{
    public class BudgetController : Controller
    {
        IBudget service;
        public BudgetController(IBudget service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            var id = HttpContext.Session.GetInt32("userId");
            if(id==0 || id == null)
            {
                return RedirectToAction("Login", "User");
            }
            var budgetList = service.GetAllBudgetsByUser(id);
            return View(budgetList);
        }

        public IActionResult Create()
        {
            var id = HttpContext.Session.GetInt32("userId");
            if (id == 0 || id == null)
            {
                return RedirectToAction("Login", "User");
            }
            ViewBag.UserID = HttpContext.Session.GetInt32("userId");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Budget b)
        {
            service.AddBudget(b);
            
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
           
            Budget budget = service.GetBudget(id);
            ViewBag.UserId = budget.UserID;
            return View(budget);
        }
        [HttpPost]
        public IActionResult Edit(Budget ex)
        {
            Budget e = service.UpdateBudget(ex);
            return RedirectToAction(nameof(Index), new { id = e.UserID });
        }

        public IActionResult Delete(int id)
        {
            Budget budget = service.GetBudget(id);
            return View(budget);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteBudget(int budgetId)
        {
            service.DeleteBudget(budgetId);
            return RedirectToAction(nameof(Index));
        }

    }
}
