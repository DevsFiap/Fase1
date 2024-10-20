using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using TechChallangeFase01.Api.Controllers;
using TechChallangeFase01.Application.Dto;
using TechChallangeFase01.Application.Interfaces;
using TechChallangeFase01.Domain.Enums;
using TechChallengeFase01.Tests.Builders;

namespace TechChallengeFase01.Tests.Controller
{
    public class ContatoControllerTests
    {
        private ContatosController _controller;
        private Mock<IContatosService> _contatosServiceMock;
        private Mock<ILogger<ContatosController>> _loggerMock;
        public ContatoControllerTests()
        {
            _contatosServiceMock = new Mock<IContatosService>();
            _loggerMock = new Mock<ILogger<ContatosController>>();

            _controller = new ContatosController(_contatosServiceMock.Object,
                _loggerMock.Object);
        }

        [Fact(DisplayName = "Obter contatos com sucesso")]
        public async Task GetContacts_Should_Return_Contacts_With_Ok_Status()
        {
            //Arrange

            var contacts = new List<ContatoDto>()
            {
                 new ContactDtoBuilder().Build()
            };

            _contatosServiceMock.Setup(x => x.GetContatos()).ReturnsAsync(contacts);

            //Act
            var result = await _controller.GetContatos();
            var okResult = result as OkObjectResult;
            var contactsResult = okResult?.Value as List<ContatoDto>;

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.NotNull(contactsResult);
            contactsResult.Should().BeEquivalentTo(contacts);
        }

        [Fact(DisplayName = "Obter contatos com retorno sem conteúdo")]
        public async Task GetContacts_Should_Return_No_Contacts_With_No_Content_Status()
        {
            //Arrange
            _contatosServiceMock.Setup(x => x.GetContatos()).ReturnsAsync((List<ContatoDto>)null);

            //Act
            var result = await _controller.GetContatos();
            var noContentResult = result as NoContentResult;

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(noContentResult);
            Assert.Equal(204, noContentResult.StatusCode);
        }

        [Fact(DisplayName = "Obter contatos com exceção")]
        public async Task GetContacts_Should_Return_Bad_Request_When_Throws_Exception()
        {
            //Arrange
            _contatosServiceMock.Setup(x => x.GetContatos()).Throws<Exception>();

            //Act
            var result = await _controller.GetContatos();
            var badRequestResult = result as BadRequestObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(badRequestResult);
            Assert.Equal(400, badRequestResult.StatusCode);
        }
    }
}
