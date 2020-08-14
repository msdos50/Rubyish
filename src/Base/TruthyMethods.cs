using System;
using System.Collections;

namespace Rubyish
{
    public static class TruthyMethods
    {
        /// <summary>
        /// Is this string a truthy value?
        /// </summary>
        public static bool Truthy(this Object obj)
        {
            switch (obj)
            {
                case bool b:
                    return b;
                case string str:
                    return str.IsTrue();
                case IEnumerable enumerable:
                {
                    foreach (var o in enumerable)
                    {
                        return true;
                    }

                    break;
                }
                case int i:
                    return i > 0;
                case double i:
                    return i > 0;
                case long i:
                    return i > 0;
                case float i:
                    return i > 0;
                case decimal i:
                    return i > 0;
                case ulong i:
                    return i > 0;
                case short i:
                    return i > 0;
                default:
                    return obj != null;
            }
            return false;
        }
    }
}
