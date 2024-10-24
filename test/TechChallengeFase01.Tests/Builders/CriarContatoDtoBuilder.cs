using TechChallangeFase01.Application.Dto;

namespace TechChallengeFase01.Tests.Builders
{
    public class CriarContatoDtoBuilder
    {
        private CriarContatoDto _contatoDto;

        public CriarContatoDtoBuilder()
        {
            _contatoDto = new CriarContatoDto
            {
                Nome = "Nome", 
                Telefone = "999999999",
                Email = "email@email.com"
            };
        }

        public CriarContatoDto Build()
        {
            return _contatoDto;
        }
    }
}
