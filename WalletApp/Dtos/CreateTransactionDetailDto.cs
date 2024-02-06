using WalletAppApi.Models;

namespace WalletApp.Api.Dtos
{
    public class CreateTransactionDetailDto
    {
        public int TransactionInitializerUserId { get; set; }
        public string TransactionInitializerUserName { get; set; } = string.Empty;
        public string TransactionName { get; set; } = string.Empty;
        public double TransactionFee { get; set; }
        public bool Pending { get; set; }
        public string TransactionDescription { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string AuthorizedUser { get; set; } = string.Empty;
        public TransactionType TransactionType { get; set; }
        public string ImagePath { get; set; }

    }
}
