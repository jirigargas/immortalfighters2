using ImmortalFighters.WebApp.ApiModels;
using ImmortalFighters.WebApp.Helpers;
using ImmortalFighters.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ImmortalFighters.WebApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ForumEntryController : ControllerBase
    {
        private readonly IForumEntryService _forumEntryService;

        public ForumEntryController(IForumEntryService forumEntryService)
        {
            _forumEntryService = forumEntryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int forumId, [FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = await _forumEntryService.GetForumEntries(forumId, page, pageSize);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateNewForumEntryRequest request)
        {
            var response = await _forumEntryService.Create(request);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int forumEntryId)
        {
            var response = await _forumEntryService.Delete(forumEntryId);
            return Ok(response);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody] UpdateForumEntryRequest request)
        {
            var response = await _forumEntryService.Update(request);
            return Ok(response);
        }
    }
}
