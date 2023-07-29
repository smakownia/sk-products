using Smakownia.Products.Domain.Entities;
using Smakownia.Products.Domain.Repositories;

namespace Smakownia.Products.Infrastructure.Repositories;

public class CategoriesRepository : CrudRepository<Category>, ICategoriesRepository
{
    public CategoriesRepository(ProductsContext productsContext) : base(productsContext) { }
}
