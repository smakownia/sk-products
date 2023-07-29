using Microsoft.AspNetCore.Mvc;
using Smakownia.Products.Application.Commands.CreateCategory;
using Smakownia.Products.Application.Commands.DeleteCategory;
using Smakownia.Products.Application.Queries.GetAllCategories;
using Smakownia.Products.Application.Queries.GetCategoryById;
using Smakownia.Products.Domain.Entities;

namespace Smakownia.Products.Api.Controllers;

[Route("api/v1/categories")]
public class CategoriesController : BaseController
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Category>>> GetAll(CancellationToken cancellationToken)
    {
        return Ok(await Sender.Send(new GetAllCategoriesQuery(), cancellationToken));
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Category>> GetById([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        return Ok(await Sender.Send(new GetCategoryByIdQuery(id), cancellationToken));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Category>> Create([FromBody] CreateCategoryCommand command,
                                                     CancellationToken cancellationToken)
    {
        var category = await Sender.Send(command, cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        await Sender.Send(new DeleteCategoryCommand(id), cancellationToken);

        return NoContent();
    }
}
