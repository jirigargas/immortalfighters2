using ImmortalFighters.WebApp.ApiModels;
using ImmortalFighters.WebApp.Helpers;
using ImmortalFighters.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImmortalFighters.WebApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = _characterService.GetMyCharacters();
            return Ok(response);
        }

        [HttpPost("[action]")]
        public IActionResult CreateDrdCharacter(CreateDrdCharacterRequest request)
        {
            var response = _characterService.CreateDrdCharacter(request);
            return Ok(response);
        }
    }
}
