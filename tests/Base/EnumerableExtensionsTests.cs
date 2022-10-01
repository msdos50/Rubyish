using System.Collections.Generic;
using FluentAssertions;
using Rubyish;
using Xunit;

namespace RubyishTests
{
    public class EnumerableExtensionsTests
    {
        [Fact]
        public void Empty_WhenSetIsHasValues_ReturnsFalse()
        {
            var list = new List<string>();
            list.Add("IHAVEABIGSPOON");
            list.Empty().Should().BeFalse();
        }

        [Fact]
        public void Empty_WhenSetIsEmpty_ReturnsTrue()
        {
            var list = new List<string>();
            list.Empty().Should().BeTrue();
        }

        [Fact]
        public void Empty_WhenSetIsNull_ReturnsTrue()
        {
            List<string> list = null;
            list.Empty().Should().BeTrue();
        }
    }
}