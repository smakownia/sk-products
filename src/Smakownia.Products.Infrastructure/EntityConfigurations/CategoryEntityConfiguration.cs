using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smakownia.Products.Domain.Entities;

namespace Smakownia.Products.Infrastructure.EntityConfigurations;

public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasMany<Product>()
               .WithOne()
               .HasForeignKey(p => p.CategoryId);
    }
}
