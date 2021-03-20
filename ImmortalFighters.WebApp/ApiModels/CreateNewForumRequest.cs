namespace ImmortalFighters.WebApp.ApiModels
{
    public class CreateNewForumRequest
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public RoleAccessRightRequest[] AccessRights { get; set; }
    }
}
