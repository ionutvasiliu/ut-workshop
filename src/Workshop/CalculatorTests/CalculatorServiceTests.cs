using System;
using System.Globalization;
using Xunit;
using Xunit.Abstractions;

namespace CalculatorTests
{
    public class CalculatorServiceTests
    {
        private readonly ITestOutputHelper _output;
        private readonly Calculator _target;

        public CalculatorServiceTests(ITestOutputHelper output)
        {
            _output = output;
            _target = new Calculator();
        }

        [Theory]
        [InlineData(10, 5, 2)]
        [InlineData(8, 2, 4)]
        [InlineData(8, 3, 2.667)]
        [InlineData(8.43, 5.46, 1.544)]
        [InlineData(0, 3, 0)]
        [InlineData(7, 1, 7)]
        [InlineData(5, 5, 1)]
        [InlineData(-10, 5, -2)]
        [InlineData(-10, -10, 1)]
        [InlineData(-15, -5, 3)]
        public void Divide_GivenValidParameters_ReturnsExpected(double param1, double param2, double expected)
        {
            // Act
            var actual = _target.Divide(param1, param2);

            // Assert
            Assert.Equal(expected, actual, 3);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(0.0)]
        public void Divide_ByZero_Throws(double param)
        {
            // Arrange
            var random = new Random();
            var num = random.NextDouble();
            _output.WriteLine(num.ToString(CultureInfo.InvariantCulture));

            // Act & Assert
            Assert.Throws<DivideByZeroException>(() => _target.Divide(num, param));
        }
    }

    public class Calculator
    {
        public double Divide(double operand1, double operand2)
        {
            if (operand2 == 0)
            {
                throw new DivideByZeroException();
            }

            return operand1 * 1.0 / operand2;
        }
    }
}
