using System.Collections.Generic;

namespace ImmortalFighters.WebApp.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set;}
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Character> Characters { get; set; }
        public ICollection<Quest> OrganizedQuests { get; set; }
        public ICollection<QuestEntry> QuestEntries { get; set; }
    }

}
