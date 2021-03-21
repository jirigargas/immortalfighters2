using AutoMapper;

namespace ImmortalFighters.WebApp.AutoMapper
{
    public class ForumEntryProfiles : Profile
    {
        public ForumEntryProfiles()
        {
            CreateMap<Models.ForumEntry, ApiModels.ForumEntryResponse>()
                .ForMember(x => x.UserName, o => o.MapFrom(x => x.User.Username));
        }
    }
}
