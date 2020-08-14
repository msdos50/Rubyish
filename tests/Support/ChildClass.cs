namespace RubyishTests.Support
{
    public class ChildClass : BaseClass
    {
        private string _prop1 = "";
        public string ChildPropertyOne { get => _prop1; set => _prop1 = value; }
        public string ChildPropertyTwo { get;}
        
        
        public ChildClass()
        {
            ChildPropertyTwo = "ReadOnly";
        }
        
        public string IAmAChildMethod(string input)
        {
            return "Banana";
        }
    }
}