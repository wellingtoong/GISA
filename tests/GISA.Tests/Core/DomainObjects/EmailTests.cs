using System;
using FluentAssertions;
using GISA.Core.DomainObjects;
using Xunit;

namespace GISA.Tests.Core.DomainObjects
{
    public class EmailTests
    {
        [Theory]
        [InlineData("ma@hostname.com")]
        [InlineData("ma@hostname.comcom")]
        [InlineData("MA@hostname.coMCom")]
        [InlineData("MA@HOSTNAME.COM")]
        [InlineData("m.a@hostname.co")]
        [InlineData("m_a1a@hostname.com")]
        [InlineData("ma-a@hostname.com")]
        [InlineData("ma-a@hostname.com.edu")]
        [InlineData("ma-a.aa@hostname.com.edu")]
        [InlineData("ma.h.saraf.onemore@hostname.com.edu")]
        [InlineData("ma12@hostname.com")]
        [InlineData("12@hostname.com")]
        public void Devera_NaoLancarExcecao_AoInstanciarEmail(string endereco)
        {
            // Arrange
            // Act
            Action act = () => new Email(endereco);

            // Assert
            act.Should().NotThrow();
        }

        [Theory]
        [InlineData("")] // Empty
        [InlineData(" ")] // Whitespaces
        [InlineData("Abc.example.com")] // No `@`
        [InlineData("A@b@c@example.com")] // multiple `@`
        [InlineData("ma...ma@jjf.co")] // continuous multiple dots in name
        [InlineData("ma@jjf.c")] // only 1 char in extension
        [InlineData("ma@jjf..com")] // continuous multiple dots in domain
        [InlineData("ma@@jjf.com")] // continuous multiple `@`
        [InlineData("@majjf.com")] // nothing before `@`
        [InlineData("ma.@jjf.com")] // nothing after `.`
        [InlineData("ma_@jjf.com")] // nothing after `_`
        [InlineData("ma_@jjf")] // no domain extension
        [InlineData("ma_@jjf.")] // nothing after `_` and .
        [InlineData("ma@jjf.")] // nothing after `.`
        public void Devera_LancarExcecaoDomainException_AoInstanciarEmail(string endereco)
        {
            // Arrange
            const string errorMessageExpected = "E-mail inválido";

            // Act
            Action act = () => new Email(endereco);

            // Assert
            act.Should().ThrowExactly<DomainException>().WithMessage(errorMessageExpected);
        }
    }
}
