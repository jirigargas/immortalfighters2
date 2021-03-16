using ImmortalFighters.WebApp.ApiModels;
using ImmortalFighters.WebApp.Helpers;
using ImmortalFighters.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;

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
            var response = _forumService.GetAll();
            return Ok(response);
        }

        [HttpPost]
        [AuthorizeRoles(Consts.RoleModerator)]
        public IActionResult Post(CreateNewForumRequest request)
        {
            throw new NotImplementedException();
        }

    }
}
