using System;

namespace ImmortalFighters.WebApp.Settings
{
    public class SecurityOptions
    {
        public string Secret { get; set; }
        public TimeSpan TokenExpirationTimeout { get; set; }
    }
}
