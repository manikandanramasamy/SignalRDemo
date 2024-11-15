using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GracefullShoutdown
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Message = "Hello from the .NET Core Web API!" });
        }
    }
}
