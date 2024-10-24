using TechChallangeFase01.Application.Dto;
using TechChallangeFase01.Domain.Enums;

namespace TechChallengeFase01.Tests.Builders
{
    public class ContactDtoBuilder
    {
        private ContatoDto _contatoDto;

        public ContactDtoBuilder()
        {
            _contatoDto = new ContatoDto
            {
                Nome = "Nome",
                NumeroTelefone = "999999999",
                Email = "email@email.com",
                DDDTelefone = EnumDDD.Recife_PE,
                DataCriacao = DateTime.UtcNow
            };
        }

        public ContatoDto Build()
        {
            return _contatoDto;
        }
    }
}
