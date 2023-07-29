using Smakownia.Products.Domain.Abstractions;
using Smakownia.Products.Domain.Entities;

namespace Smakownia.Products.Domain.Repositories;

public interface IProductsRepository : ICrudRepository<Product> { }
