using System;

namespace Rubyish
{
    public static class UnixTimeStampExt
    {
        /// <summary>
        /// Return datetime from a double in unix epoch format
        /// </summary>
        public static DateTime FromUnixTimeStamp(this double unixTime)
        {
            DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            long unixTimeStampInTicks = (long) (unixTime * TimeSpan.TicksPerSecond);

            return new DateTime(unixStart.Ticks + unixTimeStampInTicks, System.DateTimeKind.Utc);
        }

        /// <summary>
        /// Return datetime from a double in unix epoch format
        /// </summary>
        public static DateTime FromUnixTimeStamp(this long unixTime)
        {
            DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            long unixTimeStampInTicks = (long) (unixTime * TimeSpan.TicksPerSecond);

            return new DateTime(unixStart.Ticks + unixTimeStampInTicks, System.DateTimeKind.Utc);
        }
    }
}
