using Microsoft.EntityFrameworkCore;
using TechChallangeFase01.Domain.Core;
using TechChallangeFase01.Infra.Data.Context;

namespace TechChallangeFase01.Infra.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;
        private bool _disposed = false;
        public BaseRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        public void Alterar(T entidade)
        {
            if (entidade == null) throw new ArgumentNullException(nameof(entidade));
            _dbSet.Update(entidade);
            _context.SaveChanges();
        }

        public async Task Atualizar(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Criar(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Deletar(int id)
        {
            var entity = ObterPorId(id);
            if (entity == null) throw new InvalidOperationException("Entity not found.");
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) {
            if (!_disposed) {
                if (disposing) {
                    
                    _context?.Dispose();
                }
                _disposed = true;
            }
        }

        public T ObterPorId(int id)
        {
            return _dbSet.Find(id);
        }

        Task<T> IBaseRepository<T>.ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        async Task<List<T>> IBaseRepository<T>.ObterTodos()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
