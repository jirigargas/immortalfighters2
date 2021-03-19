using AutoMapper;
using ImmortalFighters.WebApp.ApiModels;
using ImmortalFighters.WebApp.Models;

namespace ImmortalFighters.WebApp.AutoMapper
{
    public class ForumProfile : Profile
    {
        public ForumProfile()
        {
            CreateMap<Forum, ForumResponse>();
        }
    }
}
