using ImmortalFighters.WebApp.ApiModels;
using ImmortalFighters.WebApp.Helpers;
using ImmortalFighters.WebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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

        private static readonly Dictionary<string, List<byte[]>> _fileSignature = new Dictionary<string, List<byte[]>>
        {
            { "jpeg", new List<byte[]>
                {
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 }
                }
            },
            { "jpg", new List<byte[]>
                {
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE1 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE8 }
                }
            }
        };

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

        [HttpPost("[action]")]
        public async Task<ActionResult> UploadAvatar()
        {
            var file = Request.Form.Files[0];
            var charactedId = Convert.ToInt32(Request.Form["CharacterId"].FirstOrDefault());

            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            var bytes = memoryStream.ToArray();

            var signatures = _fileSignature[file.FileName.Split('.').Last()];
            var headerBytes = bytes.Take(signatures.Max(m => m.Length));

            var isKnownSignature = signatures.Any(signature => headerBytes.Take(signature.Length).SequenceEqual(signature));

            if (!isKnownSignature) throw new ApiResponseException();

            var base64File = Convert.ToBase64String(memoryStream.ToArray());
            _characterService.SetAvatar(charactedId, base64File);

            return Ok();
        }

        [HttpGet("{characterId:int}")]
        public IActionResult GetById(int characterId)
        {
            var response = _characterService.GetDetail(characterId);
            return Ok(response);
        }
    }
}
