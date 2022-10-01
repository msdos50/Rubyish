using System;

namespace Rubyish
{
    public class MethodMissingException : Exception
    {
        public MethodMissingException(string message) : base(message)
        {
        }

        public MethodMissingException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}