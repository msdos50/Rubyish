using FluentAssertions;
using Rubyish;
using Xunit;

namespace RubyishTests
{
    public class UnixTimeStampExtTests
    {
        [Fact]
        public void FromUnixTimestamp_WhenPassedUnixTimeAsLong_ReturnsDateTime()
        {
            // 01/01/2000 @ 00:00:00
            long unixTimeStamp = 946684800;
            var dt = unixTimeStamp.FromUnixTimeStamp();
            dt.Day.Should().Be(01);
            dt.Month.Should().Be(01);
            dt.Year.Should().Be(2000);
            dt.Hour.Should().Be(00);
            dt.Minute.Should().Be(00);
        }

        [Fact]
        public void FromUnixTimestamp_WhenPassedUnixTimeAsDouble_ReturnsDateTime()
        {
            // 01/01/2000 @ 00:00:00
            double unixTimeStamp = 946684800;
            var dt = unixTimeStamp.FromUnixTimeStamp();
            dt.Day.Should().Be(01);
            dt.Month.Should().Be(01);
            dt.Year.Should().Be(2000);
            dt.Hour.Should().Be(00);
            dt.Minute.Should().Be(00);
        }
    }
}
