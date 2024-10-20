using AutoMapper;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallangeFase01.Application.Dto;
using TechChallangeFase01.Application.Services;
using TechChallangeFase01.Domain.Entities;
using TechChallangeFase01.Infra.Data.Interfaces;
using TechChallengeFase01.Tests.Builders;

namespace TechChallengeFase01.Tests.Services
{
    public class ContatosServiceTests
    {
        private readonly Mock<IContatosRepository> _contatosRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ContatosService _contatosService;

        public ContatosServiceTests()
        {
            _contatosRepositoryMock = new Mock<IContatosRepository>();
            _mapperMock = new Mock<IMapper>();
            _contatosService = new ContatosService(_contatosRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetContatos_Should_Return_Contacts_When_Contacts_Exist()
        {
            // Arrange
            var contatos = new List<Contato> { new ContactBuilder().Build() };
            var contatoDtos = new List<ContatoDto> { new ContactDtoBuilder().Build() };

            _contatosRepositoryMock.Setup(repo => repo.ObterTodos()).ReturnsAsync(contatos);
            _mapperMock.Setup(mapper => mapper.Map<List<ContatoDto>>(contatos)).Returns(contatoDtos);

            // Act
            var result = await _contatosService.GetContatos();

            // Assert
            result.Should().BeEquivalentTo(contatoDtos);

            _contatosRepositoryMock.Verify(repo => repo.ObterTodos(), Times.Once);
            _mapperMock.Verify(mapper => mapper.Map<List<ContatoDto>>(contatos), Times.Once);
        }

        [Fact]
        public async Task GetContatos_Should_Return_Empty_List_When_Contacts_Dont_Exist()
        {
            // Arrange
            var emptyContatos = new List<Contato>();
            var emptyContatoDtos = new List<ContatoDto>();

            _contatosRepositoryMock.Setup(repo => repo.ObterTodos()).ReturnsAsync(emptyContatos);
            _mapperMock.Setup(mapper => mapper.Map<List<ContatoDto>>(emptyContatos)).Returns(emptyContatoDtos);

            // Act
            var result = await _contatosService.GetContatos();

            // Assert
            result.Should().BeEmpty();

            _contatosRepositoryMock.Verify(repo => repo.ObterTodos(), Times.Once);
            _mapperMock.Verify(mapper => mapper.Map<List<ContatoDto>>(emptyContatos), Times.Once);
        }
    }
}
