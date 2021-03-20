namespace ImmortalFighters.WebApp.ApiModels
{
    public class RoleAccessRightRequest
    {
        public int RoleId { get; set; }
        public bool CanRead { get; set; }
        public bool CanWrite { get; set; }
    }
}
