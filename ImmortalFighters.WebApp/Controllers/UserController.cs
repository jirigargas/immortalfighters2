using ImmortalFighters.WebApp.ApiModels;
using ImmortalFighters.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ImmortalFighters.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _usersService;
        private readonly IAuthenticationService _authService;

        public UserController(IUserRepository usersService, IAuthenticationService authService)
        {
            _usersService = usersService;
            _authService = authService;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Login(LoginRequest args)
        {
            var response = _authService.Authenticate(args);
            return Ok(response);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Register(RegisterRequest args)
        {
            await _usersService.Register(args);
            return Ok();
        }
    }
}
