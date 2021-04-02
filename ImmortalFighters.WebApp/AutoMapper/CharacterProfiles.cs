using AutoMapper;
using ImmortalFighters.WebApp.ApiModels;

namespace ImmortalFighters.WebApp.AutoMapper
{
    public class CharacterProfiles : Profile
    {
        public CharacterProfiles()
        {
            CreateMap<Models.DrdCharacter, CharacterResponse>()
                .ForMember(x => x.Rules, opt => opt.MapFrom(o => Rules.DraciDoupe));

            CreateMap<Models.Drd2Character, CharacterResponse>()
                .ForMember(x => x.Rules, opt => opt.MapFrom(o => Rules.DraciDoupe2));

            CreateMap<Models.DrdCharacter, DrdCharacterDetailResponse>();
            CreateMap<Models.DrdCharacter, ICharacterDetailResponse>().As<DrdCharacterDetailResponse>();
        }
    }
}
