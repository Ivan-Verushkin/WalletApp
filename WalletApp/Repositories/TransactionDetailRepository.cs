using WalletAppApi.Data;
using WalletAppApi.Models;
using WalletAppApi.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace WalletAppApi.Repositories
{
    public class TransactionDetailRepository : ITransactionDetailRepository
    {
        private readonly AppDbContext appDbContext;

        public TransactionDetailRepository(AppDbContext dbContext)
        {
            appDbContext = dbContext;
        }

        public async Task<TransactionDetail> CreateTransactionDetail(TransactionDetail transactionDetail, int destinationUserId)
        {
            var transactionList = await appDbContext.TransactionLists.FirstOrDefaultAsync(tl => tl.UserId == destinationUserId);

            if (transactionList == null)
            {
                return null;
            }

            await appDbContext.TransactionDetails.AddAsync(transactionDetail);

            if (transactionDetail.TransactionType == TransactionType.Payment) 
            {
                transactionList.CardBalance += transactionDetail.TransactionFee;

                if (transactionList.CardBalance > 1500) 
                {
                    transactionList.CardBalance = 1500;
                }
            }
            else
            {
                transactionList.CardBalance -= transactionDetail.TransactionFee;
            }

            await appDbContext.SaveChangesAsync();
            return transactionDetail;
        }

        public async Task<TransactionDetail> GetTransactionDetailByUserIdAsync(int id, int transactionDetailId)
        {
            return await appDbContext.TransactionDetails.Include(t => t.User).FirstOrDefaultAsync(t => t.UserId == id && t.Id == transactionDetailId);
        }

        public async Task<TransactionDetail> GetTransactionDetailByDetailIdAsync(int id)
        {
            return await appDbContext.TransactionDetails.Include(t => t.User).FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
