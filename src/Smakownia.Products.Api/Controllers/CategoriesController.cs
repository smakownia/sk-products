using Microsoft.AspNetCore.Authorization;
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
    public async Task<ActionResult<IEnumerable<Category>>> GetAll(CancellationToken cancellationToken)
    {
        return Ok(await Sender.Send(new GetAllCategoriesQuery(), cancellationToken));
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Category>> GetById([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        return Ok(await Sender.Send(new GetCategoryByIdQuery(id), cancellationToken));
    }

    [HttpPost, Authorize(Roles = "Admin")]
    public async Task<ActionResult<Category>> Create([FromBody] CreateCategoryCommand command,
                                                     CancellationToken cancellationToken)
    {
        var category = await Sender.Send(command, cancellationToken);

        return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
    }

    [HttpDelete("{id:guid}"), Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        await Sender.Send(new DeleteCategoryCommand(id), cancellationToken);

        return NoContent();
    }
}
