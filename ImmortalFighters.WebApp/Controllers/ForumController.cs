using AutoMapper;
using ImmortalFighters.WebApp.ApiModels;
using ImmortalFighters.WebApp.Helpers;
using ImmortalFighters.WebApp.Models;
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
        private readonly IForumRepository _forumService;
        private readonly IMapper _mapper;

        public ForumController(IForumRepository forumService, IMapper mapper)
        {
            _forumService = forumService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var user = HttpContext.Items[Consts.HttpContextUser] as User;
            var response = _forumService.GetAllAccessibleTo(user).Select(x => _mapper.Map<ForumResponse>(x));
            return Ok(response);
        }

        [HttpGet("[action]")]
        public IActionResult GroupedByCategory()
        {
            var user = HttpContext.Items[Consts.HttpContextUser] as User;
            var response = _forumService.GetAllAccessibleTo(user)
                .Select(x => _mapper.Map<ForumResponse>(x))
                .GroupBy(x => x.Category)
                .Select(x => new ForumsGroupedByCategory
                {
                    Category = x.Key,
                    Forums = x.ToList()
                });

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
