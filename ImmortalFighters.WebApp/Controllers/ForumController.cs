using ImmortalFighters.WebApp.ApiModels;
using ImmortalFighters.WebApp.Helpers;
using ImmortalFighters.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ImmortalFighters.WebApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ForumController : ControllerBase
    {
        private readonly IForumService _forumService;

        public ForumController(IForumService forumService)
        {
            _forumService = forumService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = _forumService.GetAll()
                .Select(forum => new ForumResponse
                {
                    ForumId = forum.ForumId,
                    Name = forum.Name,
                    Category = forum.Category
                }); // TODO do this using automapper;
            return Ok(response);
        }

        [HttpGet("[action]")]
        [AuthorizeRoles(Consts.RoleModerator)]
        public IActionResult Categories()
        {
            var response = _forumService.GetAllCategories();
            return Ok(response);
        }

        [HttpPost]
        [AuthorizeRoles(Consts.RoleModerator)]
        public IActionResult Post(CreateNewForumRequest request)
        {
            var forum = _forumService.Create(request);
            var response = new ForumResponse
            {
                ForumId = forum.ForumId,
                Name = forum.Name,
                Category = forum.Category
            }; // TODO do this using automapper

            return Ok(response);
        }

    }
}
