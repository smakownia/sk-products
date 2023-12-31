﻿using Smakownia.Products.Domain.Abstractions;
using Smakownia.Products.Domain.ValueObjects;

namespace Smakownia.Products.Domain.Entities;

public class Product : Entity
{
    public Product(Guid categoryId, string imageFileName, string name, string? description, Price price) : base()
    {
        CategoryId = categoryId;
        ImageFileName = imageFileName;
        Name = name;
        Description = description;
        Price = price;
    }

    protected Product() { }

    public Guid CategoryId { get; private set; }
    public string ImageFileName { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public Price Price { get; private set; }
}
