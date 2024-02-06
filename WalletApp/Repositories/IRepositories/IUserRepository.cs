using WalletAppApi.Models;

namespace WalletAppApi.Repositories.IRepositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> CreateUser(User userModel); 
        Task<User> UpdateUser(int id, User userModel);
        Task<User?> DeleteUser(int id);
        Task<TransactionList> GetUserTransactionListId(int id);
    }
}
