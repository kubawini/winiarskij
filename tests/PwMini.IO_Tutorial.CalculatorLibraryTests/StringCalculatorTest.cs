using PwMini.IO_Tutorial.CalculatorLibrary;
using System;
using Xunit;

namespace PwMini.IO_Tutorial.CalculatorLibraryTests
{
    public class StringCalculatorTest
    {
        private StringCalculator _stringCalculator;

        public StringCalculatorTest()
        {
            _stringCalculator = new StringCalculator();
        }

        [Fact]
        public void WhenEmptyStringProvided_ItShouldReturnZero()
        {
            Assert.Equal(0, _stringCalculator.Add(""));
        }

        [Theory]
        [InlineData("0", 0)]
        [InlineData("1", 1)]
        [InlineData("10", 10)]
        [InlineData("122", 122)]
        public void WhenNumberProvided_ItShouldReturnThisNumber(string input, int expected)
        {
            var result = _stringCalculator.Add(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("2,3",5)]
        public void WhenCommaSeparatedNumbersProvided_ShouldReturnSum(string input, int expected)
        {
            var result = _stringCalculator.Add(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("2\n3", 5)]
        public void WhenNewLineSeparatedNumbersProvided_ShouldReturnSum(string input, int expected)
        {
            var result = _stringCalculator.Add(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("2,3\n4",9)]
        public void WhenThreeNumbersSeparatedWithCommaOrNewLineProvided_ShouldReturnSum(string input, int expected)
        {
            var result = _stringCalculator.Add(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("-1")]
        [InlineData("-50")]
        public void WhenNegativeNumbersProvided_ThrowsException(string input)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _stringCalculator.Add(input));
        }

        [Theory]
        [InlineData("1000",0)]
        [InlineData("12,1050\n15",27)]
        [InlineData("3789220,1",1)]
        public void WhenNumberLargerThan1000_IgnoresIt(string input, int expected)
        {
            var result = _stringCalculator.Add(input);
            Assert.Equal(expected, result);
        }
    }
}