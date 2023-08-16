using Microsoft.Extensions.Configuration;
using Smakownia.Products.Domain.Repositories;

namespace Smakownia.Products.Infrastructure.Repositories;

public class FilesRepository : IFilesRepository
{
    private readonly string _rootPath;

    public FilesRepository(IConfiguration configuration)
    {
        _rootPath = configuration["contentRoot"]!;
    }

    public async Task<string> CreateAsync(Stream fileStream, CancellationToken cancellationToken = default)
    {
        var fileName = Guid.NewGuid().ToString();
        var filePath = Path.Join(_rootPath, "upload", fileName);

        using var file = File.Create(filePath);

        await fileStream.CopyToAsync(file, cancellationToken);

        await file.FlushAsync(cancellationToken);

        return fileName;
    }
}
