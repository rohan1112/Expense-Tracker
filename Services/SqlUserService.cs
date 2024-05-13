using ExpenseTrackerApp.Models;
using ExpenseTrackerApp.Repository;

namespace ExpenseTrackerApp.Services
{
    public class SqlUserService : IUserService
    {
        ApplicationContext db;
        public SqlUserService(ApplicationContext context) { 
            this.db = context;
        }
        public User AddUser(User u)
        {
            db.Add(u);
            db.SaveChanges();
            return u;
        }

        public User GetAuthDetails(string userEmail)
        {
            Console.WriteLine(userEmail);
            return db.UserTB.FirstOrDefault(u => u.Email == userEmail);
        }
    }
}
