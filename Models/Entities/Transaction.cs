using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SmartBank.Models.Entities.Account;

namespace SmartBank.Models.Entities
{
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Transaction Date")]
        public DateTime TransactionDate { get; set; } = DateTime.Now;

        [Required]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Fee")]
        public decimal Fee { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Total Amount")]
        public decimal TotalAmount => Amount + Fee;

        [Display(Name = "Description")]
        [StringLength(200)]
        public string Description { get; set; }

        [Display(Name = "Merchant Name")]
        [StringLength(100)]
        public string MerchantName { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Balance After")]
        public decimal BalanceAfter { get; set; }

        [Display(Name = "Transaction Type")]
        public string TransactionType { get; set; }  // "Deposit", "Withdrawal", "Transfer", "Payment"

        [Display(Name = "Reference")]
        public string Reference { get; set; }

        [Display(Name = "Is Reversed")]
        public bool IsReversed { get; set; } = false;

        // Foreign Keys
        [Required]
        public int AccountID { get; set; }

        [Required]
        public int CategoryID { get; set; }

        // Navigation Properties
        [ForeignKey("AccountID")]
        public virtual Account Account { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
    }
}
