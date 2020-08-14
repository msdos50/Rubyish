using FluentAssertions;
using System;
using Rubyish;
using Xunit;

namespace RubyishTests
{
    public class TimeMethodsTests
    {
        [Fact]
        public void Years_ReturnsTimeSpanInYears()
        {
            5.Years().Should().Be(TimeSpan.FromDays(5*365));
        }

        [Fact]
        public void Weeks_ReturnsTimeSpanInWeeks()
        {
            3.Weeks().Should().Be(TimeSpan.FromDays(3*7));
        }

        [Fact]
        public void Days_ReturnsTimeSpanInDays()
        {
            5.Days().Should().Be(TimeSpan.FromDays(5));
        }

        [Fact]
        public void Hours_ReturnsTimeSpanInHours()
        {
            5.Hours().Should().Be(TimeSpan.FromHours(5));
        }

        [Fact]
        public void Minutes_ReturnsTimeSpanInMinutes()
        {
            5.Minutes().Should().Be(TimeSpan.FromMinutes(5));
        }

        [Fact]
        public void Minutes_ReturnsTimeSpanInSeconds()
        {
            5.Seconds().Should().Be(TimeSpan.FromSeconds(5));
        }
    }
}
