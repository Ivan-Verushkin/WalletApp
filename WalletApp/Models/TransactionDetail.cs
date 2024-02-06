using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WalletAppApi.Models
{
    public class TransactionDetail
    {
        [Key]
        public int Id { get; set; }

        public int TransactionListId { get; set; }

        public required TransactionList TransactionList { get; set; }

        public required int TransactionInitializerUserId { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string TransactionInitializerUserName { get; set; } = string.Empty;

        public required int UserId { get; set; }

        public required User User { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string TransactionName { get; set; } = string.Empty;

        [Column(TypeName = "smallint")]
        public TransactionType TransactionType { get; set; }

        [Column(TypeName = "money")]
        public double TransactionFee { get; set; }

        [Column(TypeName = "boolean")]
        public bool Pending { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string TransactionDescription { get; set; } = string.Empty;

        [Column(TypeName = "timestamp")]
        public DateTime TransactionDate { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string ImagePath { get; set; } = string.Empty;
    }

    public enum TransactionType
    {
        Payment = 0,
        Credit = 1,
    }
}
