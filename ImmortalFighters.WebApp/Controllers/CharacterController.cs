using ImmortalFighters.WebApp.ApiModels;
using ImmortalFighters.WebApp.Helpers;
using ImmortalFighters.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
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
        private readonly IImageProcessor _imageProcessor;
        public CharacterController(ICharacterService characterService, IImageProcessor imageProcessor)
        {
            _characterService = characterService;
            _imageProcessor = imageProcessor;
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

        [HttpPost("[action]")]
        public async Task<ActionResult> UploadAvatar()
        {
            var file = Request.Form.Files[0];
            var charactedId = Convert.ToInt32(Request.Form["CharacterId"].FirstOrDefault());

            var base64Image = await _imageProcessor.ConvertToBase64Async(file);
            _characterService.SetAvatar(charactedId, base64Image);

            return Ok();
        }

        [HttpGet("[action]/{characterId:int}")]
        public IActionResult GetDrdCharacter(int characterId)
        {
            var response = _characterService.GetDrdCharacterDetail(characterId);
            return Ok(response);
        }
    }
}
