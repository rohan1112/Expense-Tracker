using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerApp.UtilityClasses
{
    public class UserCredentials
    {
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
