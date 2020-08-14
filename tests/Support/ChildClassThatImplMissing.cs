using System;
using Rubyish;

namespace RubyishTests.Support
{
    public class ChildClassThatImplMissing : IMethodMissing
    {
        public ChildClassThatImplMissing()
        {
            
        }

        public object MethodMissing(string methodName, params object[] args)
        {
            if (methodName == "BANANA")
            {
                var returnValue = $"You passed me { args[0] }";
                return returnValue;
            }
            throw new ArgumentException($"Something bad happened");
        }
    }
}