using FluentAssertions;
using Rubyish;
using Xunit;

namespace RubyishTests
{
    public class StringMethodsTests
    {
        [Fact]
        public void IsTrue_WhenNull_ReturnsFalse()
        {
            string s = null;
            s.IsTrue().Should().BeFalse();
        }

        [Fact]
        public void IsTrue_WhenEmpty_ReturnsFalse()
        {
            string s = "";
            s.IsTrue().Should().BeFalse();
        }

        [Fact]
        public void IsTrue_WhenInvalid_ReturnsFalse()
        {
            string s = "Banana";
            s.IsTrue().Should().BeFalse();
        }

        [Fact]
        public void IsTrue_WhenPassedTrue_ReturnsTrue()
        {
            string s = "True";
            s.IsTrue().Should().BeTrue();
        }

        [Fact]
        public void ToBoolean_WhenNull_ReturnsFalse()
        {
            string s = null;
            s.ToBoolean().Should().BeFalse();
        }

        [Fact]
        public void ToBoolean_WhenEmpty_ReturnsFalse()
        {
            string s = "";
            s.ToBoolean().Should().BeFalse();
        }

        [Fact]
        public void ToBoolean_WhenInvalid_ReturnsFalse()
        {
            string s = "Banana";
            s.ToBoolean().Should().BeFalse();
        }

        [Fact]
        public void ToBoolean_WhenPassedTrue_ReturnsTrue()
        {
            string s = "True";
            s.ToBoolean().Should().BeTrue();
        }

        [Fact]
        public void ToBoolean_WhenPassedtrue_ReturnsTrue()
        {
            string s = "true";
            s.ToBoolean().Should().BeTrue();
        }

        [Fact]
        public void Present_WhenPassedNull_ReturnsFalse()
        {
            string s = null;
            s.Present().Should().BeFalse();
        }

        [Fact]
        public void Present_WhenPassedEmpty_ReturnsFalse()
        {
            string s = "";
            s.Present().Should().BeFalse();
        }

        [Fact]
        public void Present_WhenPassedString_ReturnsTrue()
        {
            string s = "Hello";
            s.Present().Should().BeTrue();
        }
    }
}
