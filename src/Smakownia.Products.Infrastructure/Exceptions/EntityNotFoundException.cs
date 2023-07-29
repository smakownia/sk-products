using Smakownia.Products.Domain.Abstractions;
using Smakownia.Products.Domain.Exceptions;

namespace Smakownia.Products.Infrastructure.Exceptions;

public class EntityNotFoundException<T> : NotFoundException where T : Entity
{
    public EntityNotFoundException() : base($"{typeof(T).Name} not found") { }

    public EntityNotFoundException(Guid id) : base($"{typeof(T).Name} with id: '{id}' not found") { }
}
