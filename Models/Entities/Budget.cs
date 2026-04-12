using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartBank.Models.Entities
{
    public class Budget
    {
        [Key]
        public int BudgetID { get; set; }

        [Required]
        [Display(Name = "Budget Name")]
        public string BudgetName { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Monthly Limit")]
        public decimal MonthlyLimit { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Spent So Far")]
        public decimal SpentSoFar { get; set; }

        [Display(Name = "Remaining")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Remaining => MonthlyLimit - SpentSoFar;

        [Display(Name = "Percentage Used")]
        public decimal PercentageUsed => MonthlyLimit > 0 ? (SpentSoFar / MonthlyLimit) * 100 : 0;

        [Required]
        [Range(1, 12)]
        public int Month { get; set; }

        [Required]
        public int Year { get; set; } = DateTime.Now.Year;

        [Display(Name = "Send Alert at")]
        [DisplayFormat(DataFormatString = "{0:P}")]
        public decimal AlertThreshold { get; set; } = 0.8m;  // 80% of budget

        // Foreign Keys
        [Required]
        public int CustomerID { get; set; }

        [Required]
        public int CategoryID { get; set; }

        // Navigation Properties
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
    }
}