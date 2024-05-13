using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTrackerApp.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        public int ExpenseID { get; set; }

        [Required]
        [MaxLength(20)]
        public string Action { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal OldAmount { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal NewAmount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public User User { get; set; }
        public Expense Expense { get; set; }
    }
}
