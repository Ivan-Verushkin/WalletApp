using WalletApp.Api.Dtos;
using WalletApp.Api.Helpers;
using WalletAppApi.Dtos;
using WalletAppApi.Models;

namespace WalletAppApi.Mappers
{
    public static class TransactionDetailMapper
    {
        public static TransactionDetailDto ToTransactionDetailDto (this TransactionDetail transactionDetail)
        {
            return new TransactionDetailDto()
            {
                TransactionName = transactionDetail.TransactionName,
                TransactionDescription = transactionDetail.TransactionDescription,
                TransactionFee = transactionDetail.TransactionFee,
                Pending = transactionDetail.Pending,
                CreatedDate = transactionDetail.TransactionDate,
                TransactionDate = TransactionDetailHelper.ConvertDateToString(transactionDetail.TransactionDate),
                User = transactionDetail.User.ToUserDto(),
                //TODO - Create a method to check user who created a transaction
                AuthorizedUser = transactionDetail.TransactionInitializerUserId != transactionDetail.UserId ? transactionDetail.TransactionInitializerUserName : "",
                TransactionType = transactionDetail.TransactionType,
                TransactionInitializerUserId = transactionDetail.TransactionInitializerUserId,
                TransactionInitializerUserName = transactionDetail.TransactionInitializerUserName,
                ImagePath = transactionDetail.ImagePath,
            };
        }

        public static TransactionDetail ToTransactionDetailFromTransactionDetailDto(this CreateTransactionDetailDto transactionDetailDto, User destinationUser, TransactionList transactionList, int initializerUserId, int destinationUserId)
        {
            return new TransactionDetail()
            {
                TransactionName = transactionDetailDto.TransactionName,
                TransactionDescription = transactionDetailDto.TransactionDescription,
                TransactionFee = transactionDetailDto.TransactionFee,
                Pending = transactionDetailDto.Pending,
                TransactionDate = transactionDetailDto.CreatedDate,
                TransactionInitializerUserId = initializerUserId,
                TransactionInitializerUserName = transactionDetailDto.TransactionInitializerUserName,
                TransactionType = transactionDetailDto.TransactionType,
                TransactionList = transactionList,
                UserId = destinationUserId,
                User = destinationUser,
                TransactionListId = transactionList.Id,
                ImagePath = transactionDetailDto.ImagePath,
            };
        }
    }
}
