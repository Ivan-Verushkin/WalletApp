using WalletAppApi.Models;

namespace WalletAppApi.Dtos
{
    public class TransactionDetailDto
    {
        public int TransactionInitializerUserId { get; set; }
        public string TransactionInitializerUserName { get; set; } = string.Empty;
        public string TransactionName { get; set; } = string.Empty;
        public double TransactionFee { get; set; }
        public bool Pending { get; set; }
        public string TransactionDescription { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string TransactionDate { get; set; } = string.Empty;
        public required UserDto User { get; set; }
        public string AuthorizedUser { get; set; } = string.Empty;
        public TransactionType TransactionType { get; set; }
        public string ImagePath { get; set; }
    }
}
