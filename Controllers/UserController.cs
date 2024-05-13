using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ExpenseTrackerApp.Models;
using ExpenseTrackerApp.Services;
using ExpenseTrackerApp.UtilityClasses;

namespace ExpenseTrackerApp.Controllers
{
    public class UserController : Controller
    {
        IUserService service;
        public UserController(IUserService service) { 
            this.service = service;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }



        //Login Page with Form view
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        //Login authentication
        public IActionResult Login(UserCredentials u)
        {
            User user = service.GetAuthDetails(u.Email);
            if (user.Password == u.Password)
            {
                HttpContext.Session.SetString("Email", user.Email);
                HttpContext.Session.SetInt32("userId",user.UserID);
                return RedirectToAction("Index","Expense",new {id=user.UserID});

            }
            return RedirectToAction(nameof(Error));
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Error(string message)
        {
            ViewBag.Message=message;
            return View();
        }

        //public IActionResult GoBack()
        //{
        //    // Redirect the user back to the previous page
        //    return Redirect(Request.Headers["Referer"].ToString());
        //}

        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(User u)
        {
            User user=service.AddUser(u);
            return RedirectToAction(nameof(Login));
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));
        }

    }
}
