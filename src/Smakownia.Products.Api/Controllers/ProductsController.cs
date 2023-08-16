using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Smakownia.Products.Application.Commands.CreateProduct;
using Smakownia.Products.Application.Commands.DeleteProduct;
using Smakownia.Products.Application.Dtos;
using Smakownia.Products.Application.Queries.GetAllProducts;
using Smakownia.Products.Application.Queries.GetProductById;
using Smakownia.Products.Domain.Entities;

namespace Smakownia.Products.Api.Controllers;

[Route("api/v1/products")]
public class ProductsController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll([FromQuery] GetAllProductsQuery query,
                                                                    CancellationToken cancellationToken)
    {
        return Ok(await Sender.Send(query, cancellationToken));
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ProductDto>> GetById([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        return Ok(await Sender.Send(new GetProductByIdQuery(id), cancellationToken));
    }

    [HttpPost, Authorize(Roles = "Admin")]
    public async Task<ActionResult<ProductDto>> Create([FromForm] CreateProductCommand command,
                                                       CancellationToken cancellationToken)
    {
        var product = await Sender.Send(command, cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    [HttpDelete("{id:guid}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        await Sender.Send(new DeleteProductCommand(id), cancellationToken);

        return NoContent();
    }
}
