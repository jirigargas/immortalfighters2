using ImmortalFighters.WebApp.ApiModels;
using ImmortalFighters.WebApp.Helpers;
using ImmortalFighters.WebApp.Services;
using Microsoft.AspNetCore.Mvc;

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

            if (!response.IsValid)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Register(RegisterRequest args)
        {
            var response = _usersService.Register(args);

            if (!response.IsValid)
                return BadRequest(response.Message);

            return Ok();
        }
    }
}
