using PartsDomain;
using System;
using Xunit;

namespace PartsDomainTest
{
    public class PartNumberTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void WhenPartNumberEmpty_ThenParseShouldThrow(string input)
        {
            Assert.Throws<ArgumentNullException>(() => PartNumber.Parse(input));
        }

        [Theory]
        [InlineData("123")]
        [InlineData("asdf")]
        [InlineData("123-")]
        [InlineData("asdf-")]
        [InlineData("-123")]
        [InlineData("-asdf")]
        [InlineData("a234-abcd")]
        [InlineData("123-abcd")]
        [InlineData("1234-asd")]
        [InlineData("1234--asdf")]
        public void WhenPartNumberInvalid_ThenParseShouldThrow(string input)
        {
            Assert.Throws<ArgumentException>(() => PartNumber.Parse(input));
        }

        [Theory]
        [InlineData("1234-asdf", "1234")]
        [InlineData("5678-partcode", "5678")]
        public void PartIdCanBeParsedCorrectly(string input, string expected)
        {
            var partNumber = PartNumber.Parse(input);
            Assert.Equal(expected, partNumber.PartId);
        }

        [Theory]
        [InlineData("1234-asdf", "asdf")]
        [InlineData("5678-partcode", "partcode")]
        public void PartCodeCanBeParsedCorrectly(string input, string expected)
        {
            var partNumber = PartNumber.Parse(input);
            Assert.Equal(expected, partNumber.PartCode);
        }
    }
}