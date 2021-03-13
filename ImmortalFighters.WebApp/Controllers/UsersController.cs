using ImmortalFighters.WebApp.ApiModels;
using ImmortalFighters.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ImmortalFighters.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Login(LoginRequest args)
        {
            var response = _usersService.Authenticate(args);
            return Ok(response);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Register(RegisterRequest args)
        {
            var response = await _usersService.Register(args);
            return Ok(response);
        }
    }
}
