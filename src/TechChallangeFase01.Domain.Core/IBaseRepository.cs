namespace TechChallangeFase01.Domain.Core;

public interface IBaseRepository<T> : IDisposable
     where T : class
{

    Task Criar(T entity);
    Task Atualizar(T entity);
    void Deletar(int id);
    Task<List<T>> ObterTodos();
    Task<T> ObterPorId(int id);
}