using System;
using TimeZoneConverter;

namespace Rubyish
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// End of the day
        /// </summary>
        public static DateTime EndOfDay(this DateTime incoming)
        {
            return new DateTime(incoming.Year, incoming.Month, incoming.Day, 23, 59, 59, 999);
        }
        
        /// <summary>
        /// Return datetime in UTC
        /// </summary>
        public static DateTime EstToUtc(this DateTime incomingDateTime)
        {
            TimeZoneInfo easternZone = TZConvert.GetTimeZoneInfo("Eastern Standard Time");
            DateTime utc = TimeZoneInfo.ConvertTimeToUtc(incomingDateTime, easternZone);
            return utc;
        }
        
        /// <summary>
        /// Start of the day
        /// </summary>
        public static DateTime StartOfDay(this DateTime incoming)
        {
            return new DateTime(incoming.Year, incoming.Month, incoming.Day, 0, 0, 0, 0);
        }
        
        /// <summary>
        /// Return a double representing this datetime in unix epoch format
        /// </summary>
        public static double ToTimeStamp(this DateTime dateTime)
        {
            var result = (int) dateTime.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;

            return result;
        }

        /// <summary>
        /// Return datetime in EST
        /// </summary>
        public static DateTime ToEst(this DateTime incomingDateTime)
        {
            TimeZoneInfo easternZone = TZConvert.GetTimeZoneInfo("Eastern Standard Time");
            DateTime inEst = TimeZoneInfo.ConvertTime(incomingDateTime, easternZone);
            return inEst;
        }
    }
}
