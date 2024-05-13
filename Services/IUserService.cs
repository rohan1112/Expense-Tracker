using ExpenseTrackerApp.Models;

namespace ExpenseTrackerApp.Services
{
    public interface IUserService
    {
        User AddUser(User u);
        User GetAuthDetails(string Email);
        //string UpdateUser(User u);
        //string DeleteUser(User u);

    }
}
