namespace Smakownia.Products.Domain.Abstractions;

public interface IUnitOfWork
{
    Task CommitAsync(CancellationToken token = default);
}
