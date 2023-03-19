using Microsoft.AspNetCore.Mvc;

namespace Template.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckController : ControllerBase
    {
        [HttpGet()]
        public IActionResult Check()
        {
            return Ok("Server is running ...");
        }
    }
}