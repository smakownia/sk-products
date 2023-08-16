using Microsoft.EntityFrameworkCore;
using Smakownia.Products.Domain.Abstractions;
using Smakownia.Products.Infrastructure.Exceptions;
using System.Linq.Expressions;

namespace Smakownia.Products.Infrastructure.Repositories;

public abstract class CrudRepository<T> : ICrudRepository<T> where T : Entity
{
    private readonly ProductsContext _productsContext;

    protected CrudRepository(ProductsContext productsContext)
    {
        _productsContext = productsContext;
    }

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = default,
                                                  CancellationToken cancellationToken = default)
    {
        IQueryable<T> query = _productsContext.Set<T>();

        if (predicate is not null)
        {
            query = query.Where(predicate);
        }

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await _productsContext.Set<T>()
                                           .Where(e => e.Id == id)
                                           .FirstOrDefaultAsync(cancellationToken);

        if (entity is null)
            throw new EntityNotFoundException<T>(id);

        return entity;
    }

    public void Add(T entity)
    {
        _productsContext.Add(entity);
    }

    public void Remove(T entity)
    {
        _productsContext.Remove(entity);
    }
}
