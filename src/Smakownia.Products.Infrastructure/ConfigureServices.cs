using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smakownia.Products.Domain.Abstractions;
using Smakownia.Products.Domain.Repositories;
using Smakownia.Products.Infrastructure.Repositories;

namespace Smakownia.Products.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host(new Uri(configuration.GetConnectionString("RabbitMQ")!));
            });
        });

        services.AddDbContext<ProductsContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("MsSql")));

        services.AddTransient<IProductsRepository, ProductsRepository>();
        services.AddTransient<ICategoriesRepository, CategoriesRepository>();
        services.AddTransient<IFilesRepository, FilesRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IEventBus, EventBus>();

        return services;
    }
}
