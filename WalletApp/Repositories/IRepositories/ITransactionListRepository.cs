using WalletAppApi.Models;

namespace WalletAppApi.Repositories.IRepositories
{
    public interface ITransactionListRepository
    {
        Task<TransactionList> GetTransactionListByUserIdAsync(int id);

        Task<bool> TransactionListExists(int id);
    }
}
