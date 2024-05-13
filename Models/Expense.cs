using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTrackerApp.Models
{
    public class Expense
    {
        [Key]
        public int ExpenseID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Category { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal RemainingAmount { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public User User { get; set; }
    }
}
