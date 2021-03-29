using AutoMapper;
using ImmortalFighters.WebApp.ApiModels;
using ImmortalFighters.WebApp.Models;
using ImmortalFighters.WebApp.Repositories;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace ImmortalFighters.WebApp.Services
{
    public interface ICharacterService
    {
        public IEnumerable<CharacterResponse> GetMyCharacters();
        CharacterResponse CreateDrdCharacter(CreateDrdCharacterRequest createDrdCharacterRequest);
    }

    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CharacterService(ICharacterRepository characterRepository, IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
        {
            _characterRepository = characterRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public CharacterResponse CreateDrdCharacter(CreateDrdCharacterRequest createDrdCharacterRequest)
        {
            // TODO implement all the checks here

            var user = _httpContextAccessor.HttpContext.Items[Consts.HttpContextUser] as User;

            var response = _characterRepository.CreateCharacter(new DrdCharacter
            {
                User = user,
                Name = createDrdCharacterRequest.Name,
                Rasa = createDrdCharacterRequest.Race,
                Povolani = createDrdCharacterRequest.Class,
                Presvedceni = createDrdCharacterRequest.Conviction,
                Uroven = 1,
                Zkusenosti = 0,
                Zivoty = 1,
                Sila = 1,
                Obratnost = 1,
                Odolnost = 1,
                Inteligence = 1,
                Charisma = 1
            });
            return _mapper.Map<CharacterResponse>(response);
        }

        public IEnumerable<CharacterResponse> GetMyCharacters()
        {
            var user = _httpContextAccessor.HttpContext.Items[Consts.HttpContextUser] as User;
            var response = _characterRepository.GetByUserId(user.UserId);
            return response.Select(x => _mapper.Map<CharacterResponse>(x));
        }
    }
}
