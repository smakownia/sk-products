using System.Linq.Expressions;

namespace Smakownia.Products.Domain.Abstractions;

public interface ICrudRepository<T> where T : Entity
{
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = default,
                                     CancellationToken cancellationToken = default);
    Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(T entity);
    void Remove(T entity);
}
