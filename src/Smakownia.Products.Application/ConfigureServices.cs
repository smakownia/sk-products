using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Smakownia.Products.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
                                                            IConfiguration configuration)
    {
        services.AddAutoMapper(cfg => cfg.AddProfile(new ProductsMapperProfile(configuration)));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(AssemblyReference.Assembly));

        return services;
    }
}
