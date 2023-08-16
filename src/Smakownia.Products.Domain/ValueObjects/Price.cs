using Smakownia.Products.Domain.Exceptions;

namespace Smakownia.Products.Domain.ValueObjects;

public record Price
{
    private Price(long value)
    {
        Value = value;
    }

    public long Value { get; init; }

    public static Price Create(long value)
    {
        if (value <= 0)
            throw new ValidationException("Price must be 1 or more");

        return new(value);
    }
}
