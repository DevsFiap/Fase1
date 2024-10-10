using TechChallangeFase01.Application.Dto;

namespace TechChallangeFase01.Application.Interfaces
{
    public interface IContatosService
    {
        Task<List<ContatoDto>> GetContatos();
    }
}
