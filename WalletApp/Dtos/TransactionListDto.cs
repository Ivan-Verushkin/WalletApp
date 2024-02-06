using WalletAppApi.Models;

namespace WalletAppApi.Dtos
{
    public class TransactionListDto
    {
        public double MaxBalance { get; set; }
        public double AvailableBalance { get; set; }
        public double? CardBalance { get; set; }
        public int CurrentUserId { get; set; }
        public string NoPaymentDue { get; set; } = string.Empty;
        public string Points { get; set; }
        public required UserDto CurrentUser { get; set; }
        public IEnumerable<TransactionDetailDto>? TransactionDetails { get; set; }
    }
}
