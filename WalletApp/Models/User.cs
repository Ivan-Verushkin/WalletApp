using System.ComponentModel.DataAnnotations;

namespace WalletAppApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public DateTime Created { get; set; } = DateTime.Now;

        public IEnumerable<TransactionDetail>? TransactionDetails { get; set; }

        public TransactionList? TransactionList { get; set; }
    }
}
