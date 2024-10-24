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
using TechChallangeFase01.Domain.Interfaces.Repositories;
using TechChallangeFase01.Domain.Interfaces.Services;
using TechChallengeFase01.Tests.Builders;

namespace TechChallengeFase01.Tests.Services
{
    public class ContatosServiceTests
    {
        private readonly Mock<IContatoDomainService> _contatoDomainServiceMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ContatosAppService _contatosService;

        public ContatosServiceTests()
        {
            _contatoDomainServiceMock = new Mock<IContatoDomainService>();
            _mapperMock = new Mock<IMapper>();
            _contatosService = new ContatosAppService(_contatoDomainServiceMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task GetContatos_Should_Return_Contacts_When_Contacts_Exist()
        {
            // Arrange
            var contatos = new List<Contato> { new ContactBuilder().Build() };
            var contatoDtos = new List<ContatoDto> { new ContactDtoBuilder().Build() };

            _contatoDomainServiceMock.Setup(repo => repo.BuscarContatos()).ReturnsAsync(contatos);
            _mapperMock.Setup(mapper => mapper.Map<List<ContatoDto>>(contatos)).Returns(contatoDtos);

            // Act
            var result = await _contatosService.GetContatos();

            // Assert
            result.Should().BeEquivalentTo(contatoDtos);

            _contatoDomainServiceMock.Verify(repo => repo.BuscarContatos(), Times.Once);
            _mapperMock.Verify(mapper => mapper.Map<List<ContatoDto>>(contatos), Times.Once);
        }

        [Fact]
        public async Task GetContatos_Should_Return_Empty_List_When_Contacts_Dont_Exist()
        {
            // Arrange
            var emptyContatos = new List<Contato>();
            var emptyContatoDtos = new List<ContatoDto>();

            _contatoDomainServiceMock.Setup(repo => repo.BuscarContatos()).ReturnsAsync(emptyContatos);
            _mapperMock.Setup(mapper => mapper.Map<List<ContatoDto>>(emptyContatos)).Returns(emptyContatoDtos);

            // Act
            var result = await _contatosService.GetContatos();

            // Assert
            result.Should().BeEmpty();

            _contatoDomainServiceMock.Verify(repo => repo.BuscarContatos(), Times.Once);
            _mapperMock.Verify(mapper => mapper.Map<List<ContatoDto>>(emptyContatos), Times.Once);
        }
    }
}
