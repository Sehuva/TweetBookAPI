using Microsoft.AspNetCore.Mvc;

namespace TweetBook.Controllers
{
    public class TestController: Controller
    {
        [HttpGet("api/v1/user")]
        public IActionResult Get()
        {
            return Ok(new {name = "Sergio"});
        }
    }
}