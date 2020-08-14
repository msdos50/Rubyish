using Rubyish;

namespace RubyishTests.Support
{
    public class Duck : IMethodMissing
    {
        public string BeakColor { get; set; }

        public string Quack(string arg1, string arg2)
        {
            return "quack!!";
        }
        
        public object MethodMissing(string methodName, params object[] args)
        {
            if (methodName.StartsWith("Quack"))
            {
                var returnValue = methodName.Replace("Quack", "I know how to quack ");
                return returnValue;
            }
            throw new MethodMissingException($"I don't know what you mean");
        }
    }
}