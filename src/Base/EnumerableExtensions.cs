using System.Collections.Generic;
using System.Linq;

namespace Rubyish
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Is this collection empty?
        /// </summary>
        public static bool Empty<T>(this IEnumerable<T> source)
        {
            return !(source?.Any() ?? false);
        }
    }
}
