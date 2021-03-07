using Microsoft.EntityFrameworkCore;

namespace ImmortalFighters.WebApp.Models
{
    public class IfDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Quest> Quests { get; set; }
        public DbSet<QuestCharacter> QuestCharacters { get; set; }
        public DbSet<QuestEntry> QuestEntries { get; set; }
    }
}
