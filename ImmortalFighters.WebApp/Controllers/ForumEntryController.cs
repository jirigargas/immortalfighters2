using AutoMapper;
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
        private readonly IForumEntryRepository _repository;
        private readonly IMapper _mapper;

        public ForumEntryController(IForumEntryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] int forumId, [FromQuery] int page, [FromQuery] int pageSize)
        {
            return Ok(new string[] { "first", "second" });
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateNewForumEntryRequest request)
        {
            var result = await _repository.Create(request);
            var response = _mapper.Map<ForumEntryResponse>(result);
            return Ok(response);
        }
    }
}
