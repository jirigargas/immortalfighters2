using ImmortalFighters.WebApp.ApiModels;
using ImmortalFighters.WebApp.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace ImmortalFighters.WebApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ForumEntryController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromQuery] int forumId, [FromQuery] int page, [FromQuery] int pageSize)
        {
            return Ok(new string[] { "first", "second" });
        }

        [HttpPost]
        public IActionResult Post(CreateNewForumEntryRequest request)
        {
            throw new ApiResponseException
            {
                StatusCode = 403,
                ClientMessage = "Na tohle nemáš dostatnečná práva"
            };
        }
    }
}
