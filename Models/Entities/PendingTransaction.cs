using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static SmartBank.Models.Entities.Account;

namespace SmartBank.Models.Entities
{
    public class PendingTransaction
    {
        [Key]
        public int PendingTransactionID { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Transaction Date")]
        public DateTime TransactionDate { get; set; } = DateTime.Now;

        [Required]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Amount { get; set; }

        [Display(Name = "Merchant Name")]
        public string MerchantName { get; set; }

        [Display(Name = "Expected Clear Date")]
        [DataType(DataType.Date)]
        public DateTime ExpectedClearDate { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        // Foreign Keys
        [Required]
        public int AccountID { get; set; }

        // Navigation Property
        [ForeignKey("AccountID")]
        public virtual Account Account { get; set; }
    }
}