using Microsoft.AspNetCore.Mvc;
using TweetBook.Contracts.V1;

namespace TweetBook.Controllers
{
    public class TestController: Controller
    {
        [HttpGet(ApiRoutes.Posts.GetAll)]
        public IActionResult Get()
        {
            return Ok(new {name = "Sergio"});
        }
    }
}