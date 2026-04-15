using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace SmartBank.Models.Entities
{
    public class Category
    {
            [Key]
            public int CategoryID { get; set; }

            [Required]
            [Display(Name = "Category Name")]
            public string CategoryName { get; set; }  // Groceries, Transport, Entertainment, etc.

            [Display(Name = "Icon")]
            public string Icon { get; set; }  // FontAwesome or emoji icon

            [Display(Name = "Color")]
            public string Color { get; set; }  // Hex color code

            [Display(Name = "Is System Category")]
            public bool IsSystemCategory { get; set; } = false;

            [Display(Name = "Parent Category ID")]
            public int? ParentCategoryID { get; set; }

            // Navigation Properties
            public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
            public virtual ICollection<Budget> Budgets { get; set; } = new List<Budget>();
        }
    
}
