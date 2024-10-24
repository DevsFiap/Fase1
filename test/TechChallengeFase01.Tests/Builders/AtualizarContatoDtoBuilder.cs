using TechChallangeFase01.Application.Dto;

namespace TechChallengeFase01.Tests.Builders
{
    public class AtualizarContatoDtoBuilder
    {
        private AtualizarContatoDto _contatoDto;

        public AtualizarContatoDtoBuilder()
        {
            _contatoDto = new AtualizarContatoDto
            {
                Nome = "Nome",
                Telefone = "999999999",
                Email = "email@email.com"
            };
        }

        public AtualizarContatoDto Build()
        {
            return _contatoDto;
        }
    }
}
