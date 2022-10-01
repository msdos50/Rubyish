namespace Rubyish
{
    public interface IMethodMissing
    {
        object MethodMissing(string methodName, params object[] args);
    }
}