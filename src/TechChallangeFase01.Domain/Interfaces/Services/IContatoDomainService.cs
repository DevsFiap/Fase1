using TechChallangeFase01.Domain.Entities;
using TechChallangeFase01.Domain.Enums;

namespace TechChallangeFase01.Domain.Interfaces.Services;

public interface IContatoDomainService
{
    Task<List<Contato>> BuscarContatos();
    Task<Contato> GetByIdAsync(int id);
    Task<IEnumerable<Contato>> GetByDDDAsync(EnumDDD ddd);
    Task CreateContatoAsync(Contato contato);
    Task UpdateContatoAsync(int id, Contato contato);
    Task DeleteContatoAsync(int id);
}