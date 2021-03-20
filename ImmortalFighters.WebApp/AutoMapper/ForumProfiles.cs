using AutoMapper;

namespace ImmortalFighters.WebApp.AutoMapper
{
    public class ForumProfile : Profile
    {
        public ForumProfile()
        {
            CreateMap<Models.Forum, ApiModels.ForumResponse>();
        }
    }
}
