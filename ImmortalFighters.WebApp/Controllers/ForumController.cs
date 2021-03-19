using AutoMapper;
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
        private readonly IMapper _mapper;

        public ForumController(IForumService forumService, IMapper mapper)
        {
            _forumService = forumService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = _forumService.GetAll().Select(x => _mapper.Map<ForumResponse>(x));
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
            var response = _mapper.Map<ForumResponse>(forum);
            return Ok(response);
        }

    }
}
