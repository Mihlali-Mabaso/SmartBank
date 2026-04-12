using System.ComponentModel.DataAnnotations;


namespace SmartBank.Models.Entities
{
    public class AccountType
    {
        [Key]
        public int AccontTypeId { get; set; }

        [Required]
        [Display(Name = "Account type")]
        public int AccountTypeId { get; set; } //saving, cheque, Credit card

        [Display(Name = "Desciption")]
        public string AccountTypeName { get; set; }

        [Display(Name = "Monthly Fee")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]

        public decimal MonthlyFee { get; set; }

        [Display(Name = "Withdrawal Fee")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal WithdrawalFee { get; set; }

        [Display(Name = "Transfer Fee")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal TransferFee { get; set; }

        [Display(Name = "Minimum Balance")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal MinimumBalance { get; set; }

        [Display(Name = "Interest Rate")]
        [DisplayFormat(DataFormatString = "{0:P}")]
        public decimal InterestRate { get; set; }

        [Display(Name = "Overdraft Limit")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal OverdraftLimit { get; set; }

        // Navigation Property
        public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
    }



}
