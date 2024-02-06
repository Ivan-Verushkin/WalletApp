using WalletApp.Api.Helpers;
using WalletApp.Api.Services;
using WalletAppApi.Dtos;
using WalletAppApi.Models;

namespace WalletAppApi.Mappers
{
    public static class TransactionListMapper
    {
        public static TransactionListDto ToTransactionListDto(this TransactionList list)
        {
            return new TransactionListDto
            {
                CardBalance = list.CardBalance,
                MaxBalance = TransactionListHelper.MaxBalance,
                AvailableBalance = TransactionListHelper.MaxBalance - list.CardBalance,
                NoPaymentDue = $"You`ve paid your {DateTime.Now.DayOfWeek} balance",
                Points = BonusService.CalculateBonus(list.User.Created),
                CurrentUserId = list.UserId,
                CurrentUser = list.User.ToUserDto(),
                TransactionDetails = list.TransactionDetails?.OrderByDescending(td => td.TransactionDate).Take(10).Select(t => t.ToTransactionDetailDto()).ToList(),
            };
        }
    }
}
