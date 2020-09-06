using System;
using FluentAssertions;
using Rubyish;
using Xunit;

namespace RubyishTests
{
    public class DateTimeExtensionsTests
    {
        [Fact]
        public void EndOfDay_ReturnsDTAtEndOfDay()
        {
            var dt = new DateTime(2020, 01, 01, 12, 5, 7);
            dt.EndOfDay().Year.Should().Be(2020);
            dt.EndOfDay().Month.Should().Be(01);
            dt.EndOfDay().Day.Should().Be(01);
            dt.EndOfDay().Hour.Should().Be(23);
            dt.EndOfDay().Minute.Should().Be(59);
            dt.EndOfDay().Second.Should().Be(59);
            dt.EndOfDay().Millisecond.Should().Be(999);
        }
        
        [Fact]
        public void EstToUtc_ConvertsToUTC()
        {
            var dt = new DateTime(2020, 01, 01, 0, 0, 0);
            dt.EstToUtc().Hour.Should().Be(5);
        }
        
        [Fact]
        public void StartOfDay_ReturnsDTAtStartOfDay()
        {
            var dt = new DateTime(2020, 01, 01, 12, 5, 7);
            dt.StartOfDay().Year.Should().Be(2020);
            dt.StartOfDay().Month.Should().Be(1);
            dt.StartOfDay().Day.Should().Be(1);
            dt.StartOfDay().Hour.Should().Be(0);
            dt.StartOfDay().Minute.Should().Be(0);
            dt.StartOfDay().Second.Should().Be(0);
            dt.StartOfDay().Millisecond.Should().Be(0);
        }
        
        [Fact]
        public void ToTimestamp_ReturnsDateInUnixFormat()
        {
            var dt = new DateTime(2000, 01, 01, 0, 0, 0);
            dt.ToTimeStamp().Should().Be(946684800);
        }

        [Fact]
        public void ToEst_ConvertsToEasternStandardTime()
        {
            var dt = DateTime.Parse("2020-01-01T19:00:00.0000000Z");
            dt.ToEst().Hour.Should().Be(14);
        }
    }
}