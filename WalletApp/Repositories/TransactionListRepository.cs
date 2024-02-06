using WalletAppApi.Data;
using WalletAppApi.Models;
using WalletAppApi.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace WalletAppApi.Repositories
{
    public class TransactionListRepository : ITransactionListRepository
    {
        private readonly AppDbContext appDbContext;

        public TransactionListRepository(AppDbContext dbContext)
        {
            appDbContext = dbContext;
        }
        public async Task<TransactionList> GetTransactionListByUserIdAsync(int id)
        {
            return await appDbContext.TransactionLists.Include(td => td.TransactionDetails).ThenInclude(t => t.User).Include(tl => tl.User).FirstOrDefaultAsync(t => t.UserId == id);
        }

        public async Task<bool> TransactionListExists(int id)
        {
            return await appDbContext.TransactionLists.AnyAsync(t => t.Id == id);
        }
    }
}