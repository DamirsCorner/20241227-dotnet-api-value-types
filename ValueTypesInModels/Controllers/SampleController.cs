using Microsoft.AspNetCore.Mvc;
using ValueTypesInModels.Models;

namespace ValueTypesInModels.Controllers;

[Route("[controller]")]
[ApiController]
public class SampleController : ControllerBase
{
    public IActionResult Post([FromBody] SampleRequest request)
    {
        return Ok(request);
    }
}
