namespace Smakownia.Products.Application.Dtos;
public class ProductDto
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public PriceDto Price { get; set; } = new();
}
