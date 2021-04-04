using AutoMapper;
using ImmortalFighters.WebApp.ApiModels;
using ImmortalFighters.WebApp.Helpers;
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
        DrdCharacterDetailResponse GetDrdCharacterDetail(int characterId);
        void SetAvatar(int charactedId, string base64File);
    }

    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDrdCharacterCreator _drdCharacterCreator;

        public CharacterService(
            IMapper mapper,
            ICharacterRepository characterRepository,
            IHttpContextAccessor httpContextAccessor,
            IDrdCharacterCreator drdCharacterCreator)
        {
            _characterRepository = characterRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _drdCharacterCreator = drdCharacterCreator;
        }

        public CharacterResponse CreateDrdCharacter(CreateDrdCharacterRequest request)
        {
            // TODO implement all the checks here

            var user = _httpContextAccessor.HttpContext.Items[Consts.HttpContextUser] as User;
            var character = new DrdCharacter
            {
                User = user,
                Status = CharacterStatus.Active,
                Name = request.Name,
                Rasa = request.Race,
                Povolani = request.Class,
                Presvedceni = request.Conviction,
                Uroven = 1,
                Zkusenosti = 0
            };

            character.Sila = _drdCharacterCreator.GetStrength(request.Race, request.Class);
            character.Obratnost = _drdCharacterCreator.GetDexterity(request.Race, request.Class);
            character.Odolnost = _drdCharacterCreator.GetEndurance(request.Race, request.Class);
            character.Inteligence = _drdCharacterCreator.GetIntelligence(request.Race, request.Class);
            character.Charisma = _drdCharacterCreator.GetCharisma(request.Race, request.Class);
            character.Zivoty = _drdCharacterCreator.GetLives(request.Class, character.Odolnost);

            var response = _characterRepository.CreateCharacter(character);
            return _mapper.Map<CharacterResponse>(response);
        }

        public DrdCharacterDetailResponse GetDrdCharacterDetail(int characterId)
        {
            // TODO implement all the checks here
            var character = _characterRepository.GetById(characterId);
            return _mapper.Map<DrdCharacterDetailResponse>(character);
        }

        public IEnumerable<CharacterResponse> GetMyCharacters()
        {
            var user = _httpContextAccessor.HttpContext.Items[Consts.HttpContextUser] as User;
            var response = _characterRepository.GetByUserId(user.UserId);
            return response.Select(x => _mapper.Map<CharacterResponse>(x));
        }

        public void SetAvatar(int charactedId, string base64File)
        {
            var character = _characterRepository.GetById(charactedId);
            var currentUser = _httpContextAccessor.HttpContext.Items[Consts.HttpContextUser] as User;
            if (character.UserId != currentUser.UserId) throw new ApiResponseException();

            _characterRepository.SetAvatar(charactedId, base64File);
        }
    }
}
