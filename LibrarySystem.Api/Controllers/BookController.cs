using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok();
    }

    [HttpPost]
    public async Task PostAsync([FromBody] string value)
    {
        
    }
}
