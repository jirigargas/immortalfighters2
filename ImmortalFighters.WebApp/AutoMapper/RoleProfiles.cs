using AutoMapper;

namespace ImmortalFighters.WebApp.AutoMapper
{
    public class RoleProfiles : Profile
    {
        public RoleProfiles()
        {
            CreateMap<Models.Role, ApiModels.Role>();
        }
    }
}
