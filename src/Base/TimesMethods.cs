using System;
using System.Collections.Generic;

namespace Rubyish
{
    public static class TimesMethods
    {
        /// <summary>
        /// Run a block of code i times
        /// </summary>
        /// <param name="i">Number of times to repeat</param>
        /// <param name="func">The code we are running</param>
        public static void Times(this int i, Action func)
        {
            if (i <= 0)
                return;
            
            for (int j = 0; j < i; j++) 
            {
                func.Invoke();
            }
        }
        
        /// <summary>
        /// Run a block of code i times
        /// </summary>
        /// <param name="i">Number of times to repeat</param>
        /// <param name="func">The code we are running</param>
        /// <typeparam name="T">The return value type</typeparam>
        /// <returns>List of all the return values</returns>
        public static List<T> Times<T>(this int i, Func<T> func)
        {
            var returnValues = new List<T>();
            
            if (i <= 0)
                return returnValues;
            
            for (int j = 0; j < i; j++) 
            {
                returnValues.Add(func.Invoke());
            }
            
            return returnValues;
        }
    }
}
