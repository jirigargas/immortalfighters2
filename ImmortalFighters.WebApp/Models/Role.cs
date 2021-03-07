using System.Collections.Generic;

namespace ImmortalFighters.WebApp.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
