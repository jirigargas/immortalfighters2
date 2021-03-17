namespace ImmortalFighters.WebApp.Models
{
    public abstract class AccessRight
    {
        public int AccessRightId { get; set; }
        public bool CanRead { get; set; }
        public bool CanWrite { get; set; }
    }

    public abstract class ForumAccessRight : AccessRight
    {
        public int ForumId { get; set; }
        public Forum Forum { get; set; }
    }

    public class ForumRoleAccessRight : ForumAccessRight
    {
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }

    public class ForumUserAccessRight : ForumAccessRight
    {
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
