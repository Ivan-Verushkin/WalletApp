using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WalletApp.Api.Services
{
    public static class BonusService 
    {
        public static string CalculateBonus(DateTime userCreatedDate)
        {
            double points = 0;

            DateTime currentDate = DateTime.Now.Date;

            Dictionary<string, double> pointsEarned = new Dictionary<string, double>();

            pointsEarned.Add("pointsGainedToday", 0);
            pointsEarned.Add("pointsGainedYesterday", 0);
            pointsEarned.Add("pointsGainedTheDayBefore", 0);

            while (true)
            {
                if (userCreatedDate.Date.Month == 3 && userCreatedDate.Date.Day == 1 
                    || userCreatedDate.Date.Month == 6 && userCreatedDate.Date.Day == 1 
                    || userCreatedDate.Date.Month == 9 && userCreatedDate.Date.Day == 1 
                    || userCreatedDate.Date.Month == 12 && userCreatedDate.Date.Day == 1)
                {
                    points += 2;
                    pointsEarned["pointsGainedTheDayBefore"] = 0;
                    pointsEarned["pointsGainedYesterday"] = 0;
                    pointsEarned["pointsGainedToday"] = 2;
                }
                else if (userCreatedDate.Month == 3 && userCreatedDate.Day == 2 
                    || userCreatedDate.Month == 6 && userCreatedDate.Day == 2 
                    || userCreatedDate.Month == 9 && userCreatedDate.Day == 2 
                    || userCreatedDate.Month == 12 && userCreatedDate.Day == 2)
                {
                    points += 3;
                    pointsEarned["pointsGainedYesterday"] = 2;
                    pointsEarned["pointsGainedToday"] = 3;
                }
                else
                {
                    pointsEarned["pointsGainedTheDayBefore"] = pointsEarned["pointsGainedYesterday"];
                    pointsEarned["pointsGainedYesterday"] = pointsEarned["pointsGainedToday"];
                    pointsEarned["pointsGainedToday"] = pointsEarned["pointsGainedTheDayBefore"] + pointsEarned["pointsGainedYesterday"] * 0.6;
                    points += pointsEarned["pointsGainedToday"];
                }

                userCreatedDate = userCreatedDate.AddDays(1);

                if (userCreatedDate.Date == currentDate.Date)
                {
                    break;
                }
            }

            points = Math.Round(points);
            StringBuilder sb = new StringBuilder();

            if (points > 1000)
            {
                sb.Append(Math.Round(points));
                return sb.Remove(sb.Length - 3, 3).ToString() + "K";
            }

            return sb.ToString();
        }
    }
}
