using TechChallangeFase01.Domain.Entities;
using TechChallangeFase01.Infra.Data.Context;
using TechChallangeFase01.Infra.Data.Interfaces;

namespace TechChallangeFase01.Infra.Data.Repository
{
    public class ContatosRepository : BaseRepository<Contato>, IContatosRepository
    {
        public ContatosRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}
