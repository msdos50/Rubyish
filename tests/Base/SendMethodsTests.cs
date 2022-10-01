using System;
using FluentAssertions;
using Rubyish;
using RubyishTests.Support;
using Xunit;

namespace RubyishTests
{
    public class SendMethodsTests
    {
        [Fact]
        public void SendWithoutType_WhenPassedValidMethods_CallsMethod_AndReturns()
        {
            var obj = new Support.Namespace.BaseClass();
            obj.Send("AnotherOne", "args").Should().Be("Another One");
        }
        
        [Fact]
        public void Send_WhenPassedValidMethods_CallsMethod_AndReturns()
        {
            var obj = new ChildClass();
            obj.Send<string>("IAmAChildMethod", "args").Should().Be("Banana");
            obj.Send<string>("IAmABaseMethod", "args").Should().Be("I Have a Big SPOON");
        }
        
        [Fact]
        public void Send_WhenPassedNonExistentMethod_ThrowsException()
        {
            var obj = new ChildClass();
            Action act = () => obj.Send<string>("IDontExist", "args");
            act.Should().Throw<MethodMissingException>();
        }
        
        [Fact]
        public void Send_WhenPassedNonExistentMethod_AndExceptionsAreOff_DoesNotThrowException()
        {
            var obj = new ChildClass();
            obj.Send<string>("IDontExist", false, "args").Should().BeNull();
        }
        
        [Fact]
        public void Send_WhenPassedNonExistentMethod_CallsMethodMissing()
        {
            var obj = new ChildClassThatImplMissing();
            obj.Send<string>("BANANA", "arg0").Should().Be("You passed me arg0");
        }
        
        [Fact]
        public void Send_WhenPassedNonExistentMethod_AndMethodMissingExceptions_ThrowsException()
        {
            var obj = new ChildClassThatImplMissing();
            Action act = () => obj.Send<string>("NotReallyThere", "arg0");
            act.Should().Throw<MethodMissingException>();
        }
        
        [Fact]
        public void Send_WhenPassedProperty_ReturnsValue()
        {
            var obj = new ChildClass();
            obj.Send<string>("BasePropertyTwo").Should().Be("ReadOnly");
        }
        
        [Fact]
        public void Send_WhenPassedPropertyAndArg_SetsValue()
        {
            var obj = new ChildClass();
            obj.Send<string>("BasePropertyOne", "I Have a new value").Should().Be("I Have a new value");
            obj.BasePropertyOne.Should().Be("I Have a new value");
        }
    }
}