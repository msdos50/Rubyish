using System;

namespace Rubyish
{
    public static class TimeMethods
    {
        /// <summary>
        /// Return a timespan representing x years
        /// </summary>
        public static TimeSpan Years(this int i)
        {
            return TimeSpan.FromDays(i * 365);
        }

        /// <summary>
        /// Return a timespan representing x weeks
        /// </summary>
        public static TimeSpan Weeks(this int i)
        {
            return TimeSpan.FromDays(i * 7);
        }

        /// <summary>
        /// Return a timespan representing x days
        /// </summary>
        public static TimeSpan Days(this int i)
        {
            return TimeSpan.FromDays(i);
        }

        /// <summary>
        /// Return a timespan representing x hours
        /// </summary>
        public static TimeSpan Hours(this int i)
        {
            return TimeSpan.FromHours(i);
        }

        /// <summary>
        /// Return a timespan representing x minutes
        /// </summary>
        public static TimeSpan Minutes(this int i)
        {
            return TimeSpan.FromMinutes(i);
        }

        /// <summary>
        /// Return a timespan representing x minutes
        /// </summary>
        public static TimeSpan Seconds(this int i)
        {
            return TimeSpan.FromSeconds(i);
        }
    }
}
