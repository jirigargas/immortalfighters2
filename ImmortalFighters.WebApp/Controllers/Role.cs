using AutoMapper;
using ImmortalFighters.WebApp.Helpers;
using ImmortalFighters.WebApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ImmortalFighters.WebApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly RoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleController(RoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }
        
        [HttpGet]
        [AuthorizeRoles(Consts.RoleModerator)]
        public IActionResult Get()
        {
            var result = _roleRepository.GetAll()
                .Select(x => _mapper.Map<ApiModels.Role>(x));
            return Ok(result);
        }
    }
}
