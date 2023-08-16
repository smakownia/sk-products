using Smakownia.Products.Domain.Abstractions;

namespace Smakownia.Products.Domain.Entities;

public class Category : Entity
{
    public Category(string name) : base()
    {
        Name = name;
    }

    public string Name { get; private set; }
}
