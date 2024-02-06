using WalletAppApi.Models;

namespace WalletAppApi.Repositories.IRepositories
{
    public interface ITransactionDetailRepository
    {
        Task<TransactionDetail> GetTransactionDetailByUserIdAsync(int id, int transactionDetailId);

        Task<TransactionDetail> CreateTransactionDetail(TransactionDetail transactionDetail, int destinationUserId);

        Task<TransactionDetail> GetTransactionDetailByDetailIdAsync(int id);
    }
}
