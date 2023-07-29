using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Smakownia.Products.Api.Controllers;

[ApiController]
public abstract class BaseController : ControllerBase
{
    protected ISender Sender => HttpContext.RequestServices.GetRequiredService<ISender>();
}
