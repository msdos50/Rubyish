using System.Linq;
using FluentAssertions;
using Rubyish;
using Xunit;

namespace RubyishTests
{
    public class TimesTests
    {
        [Fact]
        public void Times_RunsTheCode()
        {
            var value = 0;
            10.Times(() => { value += 1; });
            value.Should().Be(10);
        }
        
        [Fact]
        public void Times_WhenPassedBadValue_DoesNotRunTheCode()
        {
            var value = 0;
            (-4).Times(() => { value += 1; });
            value.Should().Be(0);
        }
        
        [Fact]
        public void Times_RunsTheCode_AndReturnsTheValues()
        {
            int value = 0;
            var returnValues = 10.Times<int>(() =>
            {
                value += 1;
                return value;
            });
            returnValues.Count().Should().Be(10);
            returnValues[9].Should().Be(10);
        }
        
        [Fact]
        public void Times_WhenPassedBadNumber_SkipsCode()
        {
            int value = 0;
            var returnValues = (-1).Times<int>(() =>
            {
                value += 1;
                return value;
            });
            returnValues.Count().Should().Be(0);
        }
    }
}