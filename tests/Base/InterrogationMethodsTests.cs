using System.Linq;
using FluentAssertions;
using Rubyish;
using RubyishTests.Support;
using Xunit;

namespace RubyishTests
{
    public class InterrogationMethodsTests
    {
        [Fact]
        public void HasProperty_WhenPassedValidProperty_ReturnsTrue()
        {
            var obj = new ChildClass();
            obj.HasProperty("ChildPropertyOne").Should().BeTrue();
            obj.HasProperty("ChildPropertyTwo").Should().BeTrue();
        }
        
        [Fact]
        public void HasProperty_WhenPassedInValidProperty_ReturnsFalse()
        {
            var obj = new ChildClass();
            obj.HasProperty("IAmNotThere").Should().BeFalse();
        }
        
        [Fact]
        public void HasProperty_WhenPassedValidPropertyFromParent_ReturnsTrue()
        {
            var obj = new ChildClass();
            obj.HasProperty("BasePropertyOne").Should().BeTrue();
            obj.HasProperty("BasePropertyTwo").Should().BeTrue();
        }
        
        [Fact]
        public void HasProperty_WhenPassedNull_ReturnsFalse()
        {
            ChildClass obj = null;
            obj.HasProperty("BasePropertyOne").Should().BeFalse();
        }
        
        [Fact]
        public void Properties_ReturnsAllPropertiesOnObject()
        {
            var obj = new ChildClass();
            var results = obj.Properties();
            results.Length.Should().Be(4);
            results.Count(x => x.Name == "BasePropertyOne").Should().Be(1);
            results.Count(x => x.Name == "BasePropertyTwo").Should().Be(1);
            results.Count(x => x.Name == "ChildPropertyOne").Should().Be(1);
            results.Count(x => x.Name == "ChildPropertyTwo").Should().Be(1);
        }
        
        [Fact]
        public void Properties_WhenPassedNull_ReturnsNoMethods()
        {
            ChildClass obj = null;
            var results = obj.Properties();
            results.Length.Should().Be(0);
        }
        
        [Fact]
        public void Methods_ReturnsAllMethodsOnObject()
        {
            var obj = new ChildClass();
            var results = obj.Methods();
            results.Length.Should().Be(12);
            results.Count(x => x.Name == "IAmABaseMethod").Should().Be(1);
            results.Count(x => x.Name == "IAmAChildMethod").Should().Be(1);
        }
        
        [Fact]
        public void Methods_WhenPassedNull_ReturnsNoMethods()
        {
            ChildClass obj = null;
            var results = obj.Methods();
            results.Length.Should().Be(0);
        }
        
        [Fact]
        public void RespondsTo_WhenPassedValidMethod_ReturnsTrue()
        {
            var obj = new ChildClass();
            obj.RespondsTo("IAmABaseMethod", "hello").Should().BeTrue();
        }
        
        [Fact]
        public void RespondsTo_WhenPassedInValidProperty_ReturnsFalse()
        {
            var obj = new ChildClass();
            obj.RespondsTo("IAmNotThere").Should().BeFalse();
        }
        
        [Fact]
        public void RespondsTo_WhenPassedInValidArgs_ReturnsFalse()
        {
            var obj = new ChildClass();
            obj.RespondsTo("IAmAChildMethod").Should().BeFalse();
        }
        
        [Fact]
        public void RespondsTo_WhenPassedNull_ReturnsFalse()
        {
            ChildClass obj = null;
            obj.RespondsTo("IAmAChildMethod").Should().BeFalse();
        }
        
        [Fact]
        public void RespondsTo_WhenPassedValidMethodFromParent_ReturnsTrue()
        {
            var obj = new ChildClass();
            obj.RespondsTo("IAmAChildMethod", "hello").Should().BeTrue();
        }
    }
}