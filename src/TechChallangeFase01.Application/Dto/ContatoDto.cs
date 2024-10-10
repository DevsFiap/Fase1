using TechChallangeFase01.Domain.Enums;

namespace TechChallangeFase01.Application.Dto
{
    public class ContatoDto
    {
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
        public EnumDDD DDDTelefone { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
