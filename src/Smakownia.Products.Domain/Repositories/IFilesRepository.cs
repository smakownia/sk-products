namespace Smakownia.Products.Domain.Repositories;

public interface IFilesRepository
{
    Task<string> CreateAsync(Stream fileStream, CancellationToken cancellationToken = default);
}
