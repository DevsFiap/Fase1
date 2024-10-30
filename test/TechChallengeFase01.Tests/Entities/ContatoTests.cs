﻿using FluentAssertions;
using Moq;
using TechChallangeFase01.Domain.Entities;
using TechChallangeFase01.Domain.Enums;
using TechChallengeFase01.Tests.Builders;

namespace TechChallengeFase01.Tests.Entities
{
    public class ContatoTests
    {
        [Fact]
        public void Contato_Create_Should_Set_Properties()
        {
            // Arrange
            var contato = new ContatoBuilder().Build();

            // Act & Assert
            contato.Should().NotBeNull();
            contato.Id.Should().Be(1);
            contato.Nome.Should().Be("Nome");
            contato.Telefone.Should().Be("(81) 99999-9999");
            contato.Email.Should().Be("email@email.com");
            contato.DDDTelefone.Should().Be(EnumDDD.Recife_PE);
            contato.DataCriacao.Date.Should().Be(DateTime.Now.Date);
        }

        [Fact]
        public void Contato_Should_Be_Initialized_With_Default_Values()
        {
            // Arrange
            var contato = new Contato();

            // Act & Assert
            contato.Id.Should().Be(0);
            contato.Nome.Should().BeNull();
            contato.Telefone.Should().BeNull();
            contato.Email.Should().BeNull();
            contato.DDDTelefone.Should().Be(It.IsAny<EnumDDD>()); // Supondo que DDD0 é o valor padrão
            contato.DataCriacao.Should().Be(DateTime.MinValue);
        }
    }
}