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

        [Theory]
        [InlineData("333-AAAA", null)]
        [InlineData("333-AAAA", "")]
        [InlineData("333-AAAA", " ")]
        [InlineData("", "name")]
        [InlineData(" ", "name")]
        [InlineData(null, "name")]
        [InlineData(null, null)]
        public void CreateMapping_WithoutRequiredFields_ReturnsNull(string reference, string name)
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
    }

    public class Person
    {
        public string Name { get; set; }
    }

    public class CaseMapperService
    {
        public CaseModel CreateMapping(Case inputCase)
        {
            if (string.IsNullOrWhiteSpace(inputCase.Reference) ||
                string.IsNullOrWhiteSpace(inputCase.Person.Name))
            {
                return null;
            }

            return new CaseModel();
        }
    }

    public class CaseModel
    {
    }

    public class Case
    {
        public string Reference { get; set; }
        public Person Person { get; set; }
    }
}
