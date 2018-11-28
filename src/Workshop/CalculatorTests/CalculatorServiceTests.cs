using Shouldly;
using Xunit;

namespace CalculatorTests
{
    public class CalculatorServiceTests
    {
        private readonly Calculator _target;

        public CalculatorServiceTests()
        {
            _target = new Calculator();
        }

        [Theory]
        [InlineData(10, 5, 2)]
        [InlineData(8, 2, 4)]
        [InlineData(8, 3, 2.667)]
        [InlineData(8.43, 5.46, 1.544)]
        public void Divide_GivenValidParameters_ReturnsExpected(double param1, double param2, double expected)
        {
            // Act
            var actual = _target.Divide(param1, param2);

            // Assert
            Assert.Equal(expected, actual, 3);
        }
    }

    public class Calculator
    {
        public double Divide(double operand1, double operand2)
        {
            return operand1 * 1.0 / operand2;
        }
    }
}
