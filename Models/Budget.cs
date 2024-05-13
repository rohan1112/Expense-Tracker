using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTrackerApp.Models
{
    public class Budget
    {
        [Key]
        public int BudgetID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Category { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }

        [Required]
        public int Month { get; set; }

        [Required]
        public int Year { get; set; }

        public User User { get; set; }


    }
}
