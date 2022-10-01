using FluentAssertions;
using Rubyish;
using Xunit;

namespace RubyishTests
{
    public class TypesTests
    {
        [Fact]
        public void Types_Exists_WhenTypePresent_ReturnsTrue()
        {
            Types.Exists("MethodMissingException").Should().BeTrue();
        }
        
        [Fact]
        public void Types_Exists_WhenTypeNotPresent_ReturnsFalse()
        {
            Types.Exists("IAmNotHere").Should().BeFalse();
        }
        
        [Fact]
        public void Types_ExistsWithAssembly_WhenTypePresent_ReturnsTrue()
        {
            var thisAssembly = this.GetType().Assembly;
            Types.Exists(thisAssembly, "BaseClass").Should().BeTrue();
        }
        
        [Fact]
        public void Types_First_ReturnsFirstMatchingType()
        {
            Types.First("MethodMissingException").Should().Be<MethodMissingException>();
        }
        
        [Fact]
        public void Types_First_WhenPassedAssembly_ReturnsFirstMatchingType()
        {
            var thisAssembly = this.GetType().Assembly;
            Types.First(thisAssembly,"BaseClass").Should().Be<Support.BaseClass>();
        }
        
        [Fact]
        public void Types_Find_WhenPassedAssembly_ReturnsAllMatchingType()
        {
            var thisAssembly = this.GetType().Assembly;
            var results = Types.Find(thisAssembly,"BaseClass");
            results.Count.Should().Be(2);
            results[0].FullName.Should().EndWith("BaseClass");
            results[1].FullName.Should().EndWith("BaseClass");
        }
    }
}