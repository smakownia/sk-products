using Microsoft.EntityFrameworkCore;
using Smakownia.Products.Domain.Entities;
using Smakownia.Products.Infrastructure.EntityConfigurations;

namespace Smakownia.Products.Infrastructure;

public class ProductsContext : DbContext
{
    public ProductsContext(DbContextOptions options) : base(options) { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new CategoryEntityConfiguration());
        builder.ApplyConfiguration(new ProductEntityConfiguration());
    }
}
