using System;

namespace Rubyish
{
    public static class TimeSpanExtensions
    {
        /// <summary>
        /// Timespan in total seconds rounded to nearest integer
        /// </summary>
        /// <param name="t">The timespan we are converting</param>
        public static int ToInt(this TimeSpan t)
        {
            return (int)Math.Round(t.TotalSeconds);
        }
    }
}
