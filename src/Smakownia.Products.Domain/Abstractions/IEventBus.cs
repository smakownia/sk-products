namespace Smakownia.Products.Domain.Abstractions;

public interface IEventBus
{
    Task PublishAsync<T>(T message) where T : class;
}
