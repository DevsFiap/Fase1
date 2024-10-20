using TechChallangeFase01.Domain.Core;
using TechChallangeFase01.Domain.Entities;
using TechChallangeFase01.Domain.Enums;

namespace TechChallangeFase01.Domain.Interfaces.Repositories;

public interface IContatosRepository : IBaseRepository<Contato>
{
    Task<IEnumerable<Contato>> GetByDDDAsync(EnumDDD ddd);
}