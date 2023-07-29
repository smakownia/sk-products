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
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll(CancellationToken cancellationToken)
    {
        return Ok(await Sender.Send(new GetAllProductsQuery(), cancellationToken));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductDto>> GetById([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        return Ok(await Sender.Send(new GetProductByIdQuery(id), cancellationToken));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProductDto>> Create([FromBody] CreateProductCommand command,
                                                       CancellationToken cancellationToken) {
        var product = await Sender.Send(command, cancellationToken);

        return CreatedAtAction(nameof(GetById), new {id = product.Id}, product);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        await Sender.Send(new DeleteProductCommand(id), cancellationToken);

        return NoContent();
    }
}
