using System;
using System.Collections.Generic;
using FluentAssertions;
using Rubyish;
using Xunit;

namespace RubyishTests
{
    public class TruthyMethodsTests
    {
        [Fact]
        public void Truthy_WhenPassedZeroAsDouble_ReturnsFalse()
        {
            double number = 0;
            number.Truthy().Should().BeFalse();
        }

        [Fact]
        public void Truthy_WhenPassedOneAsDouble_ReturnsTrue()
        {
            double number = 1;
            number.Truthy().Should().BeTrue();
        }

        [Fact]
        public void Truthy_WhenPassedZeroAsLong_ReturnsFalse()
        {
            long number = 0;
            number.Truthy().Should().BeFalse();
        }

        [Fact]
        public void Truthy_WhenPassedOneAsLong_ReturnsTrue()
        {
            long number = 1;
            number.Truthy().Should().BeTrue();
        }


        [Fact]
        public void Truthy_WhenPassedZeroAsFloat_ReturnsFalse()
        {
            float number = 0;
            number.Truthy().Should().BeFalse();
        }

        [Fact]
        public void Truthy_WhenPassedOneAsFloat_ReturnsTrue()
        {
            float number = 1;
            number.Truthy().Should().BeTrue();
        }


        [Fact]
        public void Truthy_WhenPassedZeroAsDecimal_ReturnsFalse()
        {
            decimal number = 0;
            number.Truthy().Should().BeFalse();
        }

        [Fact]
        public void Truthy_WhenPassedOneAsDecimal_ReturnsTrue()
        {
            decimal number = 1;
            number.Truthy().Should().BeTrue();
        }


        [Fact]
        public void Truthy_WhenPassedZeroAsULong_ReturnsFalse()
        {
            ulong number = 0;
            number.Truthy().Should().BeFalse();
        }

        [Fact]
        public void Truthy_WhenPassedOneAsULong_ReturnsTrue()
        {
            ulong number = 1;
            number.Truthy().Should().BeTrue();
        }


        [Fact]
        public void Truthy_WhenPassedZeroAsShort_ReturnsFalse()
        {
            short number = 0;
            number.Truthy().Should().BeFalse();
        }

        [Fact]
        public void Truthy_WhenPassedOneAsShort_ReturnsTrue()
        {
            short number = 1;
            number.Truthy().Should().BeTrue();
        }
        
        [Fact]
        public void Truthy_WhenPassedZero_ReturnsFalse()
        {
            0.Truthy().Should().BeFalse();
        }
        
        [Fact]
        public void Truthy_WhenPassedOne_ReturnsTrue()
        {
            1.Truthy().Should().BeTrue();
        }
        
        [Fact]
        public void Truthy_WhenPassedPositiveNumber_ReturnsTrue()
        {
            256.Truthy().Should().BeTrue();
        }
        
        [Fact]
        public void Truthy_WhenPassedNullableInt_ReturnsTrue()
        {
            int? number = 256;
            number.Truthy().Should().BeTrue();
        }
        
        [Fact]
        public void Truthy_WhenPassedNullableInt_ReturnsFalse()
        {
            int? number = 0;
            number.Truthy().Should().BeFalse();
        }
        
        [Fact]
        public void Truthy_WhenPassedNullableIntBelowZero_ReturnsFalse()
        {
            int? number = -1;
            number.Truthy().Should().BeFalse();
        }
        
        [Fact]
        public void Truthy_WhenPassedNullableIntAsNull_ReturnsFalse()
        {
            int? number = null;
            number.Truthy().Should().BeFalse();
        }
        
        [Fact]
        public void Truthy_WhenPassedNegativeNumber_ReturnsFalse()
        {
            (-100).Truthy().Should().BeFalse();
        }
        
        [Fact]
        public void Truthy_WhenPassedAnObject_ReturnsTrue()
        {
            (new Object()).Truthy().Should().BeTrue();
        }
        
        [Fact]
        public void Truthy_WhenPassedANullObject_ReturnsFalse()
        {
            Object o = null;
            o.Truthy().Should().BeFalse();
        }
        
        [Fact]
        public void Truthy_WhenPassedEmptyList_ReturnsFalse()
        {
            var items = new List<object>();
            items.Truthy().Should().BeFalse();
        }
        
        [Fact]
        public void Truthy_WhenPassedListWithItems_ReturnsTrue()
        {
            var items = new List<object>(){ new Object() };
            items.Truthy().Should().BeTrue();
        }
        
        [Fact]
        public void Truthy_WhenPassedFalse_ReturnsFalse()
        {
            false.Truthy().Should().BeFalse();
        }
        
        [Fact]
        public void Truthy_WhenPassedTrue_ReturnsTrue()
        {
           true.Truthy().Should().BeTrue();
        }
        
        [Fact]
        public void Truthy_WhenPassedFalseString_ReturnsFalse()
        {
            "false".Truthy().Should().BeFalse();
            "False".Truthy().Should().BeFalse();
        }
        
        [Fact]
        public void Truthy_WhenPassedEmptyString_ReturnsFalse()
        {
            "".Truthy().Should().BeFalse();
        }
        
        [Fact]
        public void Truthy_WhenPassedTrueString_ReturnsTrue()
        {
            "true".Truthy().Should().BeTrue();
            "True".Truthy().Should().BeTrue();
        }
    }
}