using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallangeFase01.Application.Dto;
using TechChallangeFase01.Application.Mappings;
using TechChallangeFase01.Domain.Entities;
using TechChallengeFase01.Tests.Builders;

namespace TechChallengeFase01.Tests.Mappings
{
    public class DtoToEntityMapTests
    {
        private readonly IMapper _mapper;

        public DtoToEntityMapTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DtoToEntityMap>();
            });

            _mapper = config.CreateMapper();
        }

        [Fact]
        public void Should_Map_Contact_To_ContactDto()
        {
            // Arrange
            var contato = new ContactBuilder().Build();
            // Act
            var contatoDto = _mapper.Map<ContatoDto>(contato);

            // Assert
            contatoDto.Should().NotBeNull();
            contatoDto.Nome.Should().Be(contato.Nome);
            contatoDto.Email.Should().Be(contato.Email);
            contatoDto.DataCriacao.Should().Be(contato.DataCriacao);
            contatoDto.DDDTelefone.Should().Be(contato.DDDTelefone);
            contatoDto.Telefone.Should().Be(contato.Telefone);
        }

        [Fact]
        public void Should_Map_ContactDto_To_Contact()
        {
            // Arrange
            var contatoDto = new ContactDtoBuilder().Build();

            // Act
            var contato = _mapper.Map<Contato>(contatoDto);

            // Assert
            contato.Should().NotBeNull();
            contato.Nome.Should().Be(contatoDto.Nome);
            contato.Email.Should().Be(contatoDto.Email);
            contato.DataCriacao.Should().Be(contatoDto.DataCriacao);
            contato.DDDTelefone.Should().Be(contatoDto.DDDTelefone);
            contato.Telefone.Should().Be(contatoDto.Telefone);
        }
    }
}
