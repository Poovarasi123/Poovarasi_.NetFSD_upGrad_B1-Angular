using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankManagementApp.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }

        [Required]
        public string? AccountType { get; set; }

        [Required]
        public string? Customer { get; set; }

        // Move the Column attribute here:
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Balance { get; set; }

        public string? Branch { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}