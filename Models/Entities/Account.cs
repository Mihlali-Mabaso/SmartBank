using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SmartBank.Models.Entities
{
  
        public class Account
        {
            [Key]
            public int AccountID { get; set; }

            [Required]
            [Display(Name = "Account Number")]
            public string AccountNumber { get; set; }

            [Display(Name = "Account Name")]
            public string AccountName { get; set; }

            [Display(Name = "Current Balance")]
            [DataType(DataType.Currency)]
            [DisplayFormat(DataFormatString = "{0:C}")]
            public decimal Balance { get; set; }

            [Display(Name = "Available Balance")]
            [DataType(DataType.Currency)]
            [DisplayFormat(DataFormatString = "{0:C}")]
            public decimal AvailableBalance { get; set; }

            [Display(Name = "Date Opened")]
            [DataType(DataType.Date)]
            public DateTime DateOpened { get; set; } = DateTime.Now;

            [Display(Name = "Is Active")]
            public bool IsActive { get; set; } = true;

            [Display(Name = "Is Primary Account")]
            public bool IsPrimary { get; set; } = false;

            // Foreign Keys
            [Required]
            [Display(Name = "Customer")]
            public int CustomerID { get; set; }

            [Required]
            [Display(Name = "Account Type")]
            public int AccountTypeID { get; set; }

            // Navigation Properties
            [ForeignKey("CustomerID")]
            public virtual Customer Customer { get; set; }

            [ForeignKey("AccountTypeID")]
            public virtual AccountType AccountType { get; set; }

            public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
            public virtual ICollection<PendingTransaction> PendingTransactions { get; set; } = new List<PendingTransaction>();
        }
    
}
