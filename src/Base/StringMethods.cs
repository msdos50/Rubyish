using System;

namespace Rubyish
{
    public static class StringMethods
    {
        /// <summary>
        /// Return a boolean version of this string
        /// </summary>
        public static bool to_b(this String str)
        {
            return str.ToBoolean();
        }
        
        /// <summary>
        /// Return a boolean version of this string
        /// </summary>
        public static bool ToBoolean(this String str)
        {
            var b = false;
            if (!String.IsNullOrEmpty(str))
            {
                bool.TryParse(str, out b);
            }
            return b;
        }

        /// <summary>
        /// Is this string present?
        /// </summary>
        public static bool Present(this String str)
        {
            return !String.IsNullOrEmpty(str);
        }

        /// <summary>
        /// Is this string a truthy value?
        /// </summary>
        public static bool IsTrue(this String str)
        {
            if (str.Present() && str.ToBoolean())
            {
                return true;
            }

            return false;
        }
    }
}
