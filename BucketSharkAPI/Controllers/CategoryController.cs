using Microsoft.AspNetCore.Mvc;

namespace BucketSharkAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        // Existing GET method...
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from API");
        }

        // New POST method
        [HttpPost]
        public IActionResult Post([FromBody] Category data)
        {
            // Process data...
            return Ok($"Received: {data.Name}");
        }
    }
}
