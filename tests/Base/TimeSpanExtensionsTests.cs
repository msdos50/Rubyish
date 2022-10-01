using System;
using FluentAssertions;
using Rubyish;
using Xunit;

namespace RubyishTests
{
    public class TimeSpanExtensionsTests
    {
        [Fact]
        public void ToInt_ReturnsTime_InSeconds()
        {
            1.Minutes().ToInt().Should().Be(60);
        }

        [Fact]
        public void ToInt_ReturnsTime_RoundedToNearestSecond()
        {
            var interval = TimeSpan.FromSeconds( 12.5 );
            interval.ToInt().Should().Be(12);
        }
    }
}
