using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerApp.Models
{
    [Index(nameof(Email),IsUnique=true)]
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(15,MinimumLength =8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public ICollection<Expense> Expenses { get; set; }
        public ICollection<Budget> Budgets { get; set; }

        public ICollection<Transaction> TransactionHistories { get; set; }
    }
}
