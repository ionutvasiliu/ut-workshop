using System.Collections.Generic;
using Shouldly;
using Xunit;

namespace CaseMappingTests
{
    public class CaseTests
    {
        private readonly CaseMapperService _target;

        public CaseTests()
        {
            _target = new CaseMapperService();
        }

        [Fact]
        public void CreateMapping_WithNullFinancialsField_ReturnsNull()
        {
            // Arrange
            var inputCase = new Case
            {
                Reference = "reference",
                Financials = null,
                Person = new Person
                {
                    Name = "name"
                }
            };

            // Act
            var actual = _target.CreateMapping(inputCase);

            // Assert
            actual.ShouldBeNull();
        }

        [Fact]
        public void CreateMapping_WithEmptyFinancialsField_ReturnsNull()
        {
            // Arrange
            var inputCase = new Case
            {
                Reference = "reference",
                Financials = new List<double>(),
                Person = new Person
                {
                    Name = "name"
                }
            };

            // Act
            var actual = _target.CreateMapping(inputCase);

            // Assert
            actual.ShouldBeNull();
        }

        [Theory]
        [InlineData("333-AAAA", null)]
        [InlineData("333-AAAA", "")]
        [InlineData("333-AAAA", " ")]
        [InlineData("", "name")]
        [InlineData(" ", "name")]
        [InlineData(null, "name")]
        [InlineData(null, null)]
        public void CreateMapping_WithoutReferenceOrPersonName_ReturnsNull(string reference, string name)
        {
            // Arrange
            var inputCase = new Case
            {
                Reference = reference,
                Person = new Person
                {
                    Name = name
                }
            };

            // Act
            var actual = _target.CreateMapping(inputCase);

            // Assert
            actual.ShouldBeNull();
        }

        [Fact]
        public void CreateMapping_WithRequiredFields_ReturnsCaseModel()
        {
            // Arrange
            var inputCase = new Case
            {
                Reference = "333-AAAA",
                Financials = new List<double> { 3.33, 2 },
                Person = new Person
                {
                    Name = "John Doe"
                }
            };

            // Act
            var actual = _target.CreateMapping(inputCase);

            // Assert
            actual.ShouldNotBeNull();
        }

        [Fact]
        public void CreateMapping_WithAllRequiredFields_MapsAsExpected()
        {
            // Arrange
            var inputCase = new Case
            {
                Reference = "333-AAAA",
                Financials = new List<double> { 3.33, 2 },
                Person = new Person
                {
                    Name = "John Doe"
                }
            };

            // Act
            var actual = _target.CreateMapping(inputCase);

            // Assert
            actual.Reference.ShouldBe($"AP-{inputCase.Reference}");
        }
    }
}
