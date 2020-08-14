using System;
using FluentAssertions;
using Rubyish;
using RubyishTests.Support;
using Xunit;

namespace RubyishTests
{
    public class JsonMethodsTests
    {
        [Fact]
        public void ToJson_WhenPassedObject_ConvertsToJson()
        {
            var obj = new ExamplePoco() {PropertyOne = "I am set", PropertyTwo = 100};
            var result = obj.ToJson();
            result.Should().Be("{\"PropertyOne\":\"I am set\",\"PropertyTwo\":100}");
        }
        
        [Fact]
        public void ToJson_WhenPassedObject_IgnoresNulls()
        {
            var obj = new ExamplePoco() {PropertyOne = "I am set"};
            var result = obj.ToJson();
            result.Should().Be("{\"PropertyOne\":\"I am set\"}");
        }
        
        [Fact]
        public void FromJson_WhenValidString_DeserializesIt()
        {
            var json = "{\"PropertyOne\":\"I am set\"}";
            var result = json.FromJson<ExamplePoco>();
            result.PropertyOne.Should().Be("I am set");
        }
    }
}