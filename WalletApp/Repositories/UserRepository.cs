using WalletAppApi.Data;
using WalletAppApi.Models;
using WalletAppApi.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace WalletAppApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext dbContext) 
        {
            _context = dbContext;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> CreateUser(User userModel)
        {
            await _context.Users.AddAsync(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public async Task<User> UpdateUser(int id, User userModel)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (existingUser == null)
            {
                return null;
            }

            existingUser.UserName = userModel.UserName;
            existingUser.Email = userModel.Email;

            await _context.SaveChangesAsync();

            return existingUser;
        }

        public async Task<User?> DeleteUser(int id)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (existingUser == null)
            {
                return null;
            }

            _context.Users.Remove(existingUser);
            _context.SaveChanges();
            return existingUser;
        }

        public async Task<TransactionList> GetUserTransactionListId(int id)
        {
            return await _context.TransactionLists.FirstOrDefaultAsync(u => u.UserId == id);
        }
    }
}
