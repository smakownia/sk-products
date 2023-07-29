using Smakownia.Products.Domain.Entities;
using Smakownia.Products.Domain.Repositories;

namespace Smakownia.Products.Infrastructure.Repositories;

public class ProductsRepository : CrudRepository<Product>, IProductsRepository
{
    public ProductsRepository(ProductsContext productsContext) : base(productsContext) { }
}
