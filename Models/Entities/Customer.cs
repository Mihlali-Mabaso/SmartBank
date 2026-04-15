using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SmartBank.Models.Entities
{
    public class Customer
    {
        [Key]
        public int CustormerIdD { get; set; }

       
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Frst name must be between 2 and 200")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required")]
        public string Last_Name { get; set; }

        [Display(Name = "Full name")]
        public string FullName => $"{FirstName} {Last_Name}";

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }

        
        [Display(Name = "ID Number")]
        [Required(ErrorMessage = "South African ID number is required")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "ID number must be 13 digits")]
        public string IDNumber { get; set; }

        [Display(Name = "Date Joined")]
        [DataType(DataType.Date)]
        public DateTime DateJoined { get; set; } = DateTime.Now;

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "Last Login Date")]
        [DataType(DataType.DateTime)]
        public DateTime? LastLoginDate { get; set; }

        // Navigation Properties
        public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
        public virtual ICollection<Budget> Budgets { get; set; } = new List<Budget>();
    }
}

