namespace Smakownia.Products.Domain.Abstractions;

public interface ICrudRepository<T> where T : Entity
{
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
    Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    void Add(T entity);
    void Remove(T entity);
}
