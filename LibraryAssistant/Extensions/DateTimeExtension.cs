using System;


namespace LibraryAssistant.Extensions
{
    public static class DateTimeExtension
    {
        public static DateTime AddBusinessDays(this DateTime current, int days)
        {
            var sign = Math.Sign(days);
            var unsignedDays = Math.Abs(days);
            for (var i = 0; i < unsignedDays; i++)
            {
                do
                {
                    current = current.AddDays(sign);
                } while (current.DayOfWeek == DayOfWeek.Saturday ||
                         current.DayOfWeek == DayOfWeek.Sunday);
            }
            return current;
        }


        public static double NumberOfDaysLate(this DateTime ExpectedCheckIn)
        {
            var vm = Math.Ceiling((DateTime.Now - ExpectedCheckIn).TotalDays);
            var result = Math.Ceiling((DateTime.Now - ExpectedCheckIn).TotalDays) < 1 ? 0 : vm;
            return result;
        }

    }
}
