using FluentAssertions;
using GISA.Core.Utils;
using Xunit;

namespace GISA.Tests.Core.Utils
{
    public class StringUtilsTests
    {
        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData("abcd", "")]
        [InlineData("a1b2c3d4", "1234")]
        [InlineData("1234", "1234")]
        public void Devera_RetornarApenasNumer(string input, string expected)
        {
            // Arrange
            // Act
            var act = input.ApenasNumeros();

            // Assert
            act.Should().Be(expected);
        }
    }
}