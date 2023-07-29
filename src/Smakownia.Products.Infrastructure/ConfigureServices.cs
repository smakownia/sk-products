using Microsoft.Extensions.DependencyInjection;
using Smakownia.Products.Domain.Abstractions;
using Smakownia.Products.Domain.Repositories;
using Smakownia.Products.Infrastructure.Repositories;

namespace Smakownia.Products.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddTransient<IProductsRepository, ProductsRepository>();
        services.AddTransient<ICategoriesRepository, CategoriesRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
