using TechChallangeFase01.Domain.Entities;
using TechChallangeFase01.Domain.Enums;

namespace TechChallengeFase01.Tests.Builders
{
    public class ContactBuilder
    {
        private Contato _contato;

        public ContactBuilder()
        {
            _contato = new Contato
            {
                Id = 1,
                Nome = "Nome",
                Telefone = "999999999",
                Email = "email@email.com",
                DDDTelefone = EnumDDD.Recife_PE,
                DataCriacao = DateTime.UtcNow
            };
        }

        public Contato Build()
        {
            return _contato;
        }
    }
}
