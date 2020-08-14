using System;
using FluentAssertions;
using Rubyish;
using Xunit;

namespace RubyishTests
{
    public class DateTimeExtensionsTests
    {
        [Fact]
        public void ToUnixTimestamp_ReturnsDateInUnixFormat()
        {
            var dt = new DateTime(2000, 01, 01, 0, 0, 0);
            dt.ToTimeStamp().Should().Be(946684800);
        }

        [Fact]
        public void EasternTimeZoneDateTimeToUtc_ConvertsToUTC()
        {
            var dt = new DateTime(2020, 01, 01, 0, 0, 0);
            dt.EstToUtc().Hour.Should().Be(5);
        }

        [Fact]
        public void ToUnixTimestamp_ToEasternStandardTime()
        {
            var dt = DateTime.Parse("2020-01-01T19:00:00.0000000Z");
            dt.ToEst().Hour.Should().Be(14);
        }
    }
}