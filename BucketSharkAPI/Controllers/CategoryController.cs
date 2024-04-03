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
        public IActionResult Post([FromBody] Category category_data)
        {
            string connectionString = "Data Source=D:\\rodrigcp22\\Projects\\BucketSharkAPI-V2\\BucketSharkAPI\\db.sqlite3;Version=3;";
            DatabaseManager dbManager = new DatabaseManager(connectionString);
            dbManager.UpdateCategorySums();

            return Ok($"Received: {category_data.Name}");
        }
    }
}
