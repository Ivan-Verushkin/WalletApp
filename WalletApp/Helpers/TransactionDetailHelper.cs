namespace WalletApp.Api.Helpers
{
    public static class TransactionDetailHelper
    {
        public static string ConvertDateToString(DateTime date)
        {
            if (date >= DateTime.Now.AddDays(-7))
            {
                return date.DayOfWeek.ToString();
            }
            else 
            { 
                return date.Date.ToString("dd/MM/yyyy");
            }
        }
    }
}
