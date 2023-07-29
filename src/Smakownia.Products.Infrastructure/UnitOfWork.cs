using Smakownia.Products.Domain.Abstractions;

namespace Smakownia.Products.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly ProductsContext _productsContext;

    public UnitOfWork(ProductsContext productsContext)
    {
        _productsContext = productsContext;
    }

    public async Task CommitAsync(CancellationToken token)
    {
        await _productsContext.SaveChangesAsync(token);
    }
}
