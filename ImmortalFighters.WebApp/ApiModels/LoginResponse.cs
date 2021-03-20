using System.Collections.Generic;

namespace ImmortalFighters.WebApp.ApiModels
{
    public class LoginResponse
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public ICollection<string> Roles { get; set; }
    }
}
