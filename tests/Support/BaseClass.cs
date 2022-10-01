namespace RubyishTests.Support
{
    public class BaseClass
    {
        public string BasePropertyOne { get; set; }
        public string BasePropertyTwo { get;}
        
        
        public BaseClass()
        {
            BasePropertyTwo = "ReadOnly";
        }

        public string IAmABaseMethod(string input)
        {
            return "I Have a Big SPOON";
        }
    }
}