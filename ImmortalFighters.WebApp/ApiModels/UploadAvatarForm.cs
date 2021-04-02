using Microsoft.AspNetCore.Http;

namespace ImmortalFighters.WebApp.ApiModels
{
    public class UploadAvatarForm
    {
        public string CharacterId { get; set; }
        public FormFile Avatar { get; set; }
    }
}
