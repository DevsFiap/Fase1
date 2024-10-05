namespace TechChallangeFase01.Domain.Core;

public interface IBaseDomainService<TEntity> : IDisposable
         where TEntity : class
{
    Task AddAsync(TEntity entity);
    Task ModifyAsync(TEntity entity);
    Task RemoveAsync(TEntity entity);
    Task<List<TEntity>> GetAllAsync();
}