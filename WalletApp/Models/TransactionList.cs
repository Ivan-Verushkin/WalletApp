using System.ComponentModel.DataAnnotations;

namespace WalletAppApi.Models
{
    public class TransactionList
    {
        [Key]
        public int Id { get; set; }
        public double CardBalance { get; set; }
        public int UserId { get; set; }
        public required User User { get; set; }
        public IEnumerable<TransactionDetail>? TransactionDetails { get; set; }

    }
}
