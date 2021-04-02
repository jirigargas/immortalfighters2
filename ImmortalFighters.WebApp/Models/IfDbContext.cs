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
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<CharacterEquipment> CharacterEquipment { get; set; }
        public DbSet<QuestEntry> QuestEntries { get; set; }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<AccessRight> AccessRights { get; set; }
        public DbSet<ForumEntry> ForumEntries { get; set; }

        public IfDbContext(DbContextOptions<IfDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.UseCollation("Czech_CI_AS");

            modelBuilder.Entity<User>()
                .HasIndex(x => x.Email)
                .IsUnique();
            modelBuilder.Entity<User>()
                .Property(x => x.Email)
                .IsRequired();
            modelBuilder.Entity<User>()
                .HasIndex(x => x.Username)
                .IsUnique();
            modelBuilder.Entity<User>()
                .Property(x => x.Username)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(x => x.Password)
                .IsRequired();

            modelBuilder.Entity<UserRole>()
                .HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<UserRole>()
                .HasOne(x => x.User)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder.Entity<UserRole>()
                .HasOne(x => x.Role)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasMany(x => x.Characters)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            modelBuilder.Entity<DrdCharacter>().Property(x => x.Rasa).HasColumnName("Rasa");
            modelBuilder.Entity<Drd2Character>().Property(x => x.Rasa).HasColumnName("Rasa");

            modelBuilder.Entity<DrdCharacter>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Drd2Character>().Property(x => x.Name).IsRequired();

            modelBuilder.Entity<Quest>()
                .HasOne(x => x.DungeonMaster)
                .WithMany(x => x.OrganizedQuests)
                .HasForeignKey(x => x.DungeonMasterId)
                .IsRequired();

            modelBuilder.Entity<QuestCharacter>()
                .HasKey(x => new { x.QuestId, x.CharacterId });
            modelBuilder.Entity<QuestCharacter>()
                .HasOne(x => x.Quest)
                .WithMany(x => x.QuestCharacters)
                .HasForeignKey(x => x.QuestId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder.Entity<QuestCharacter>()
                .HasOne(x => x.Character)
                .WithMany(x => x.QuestCharacters)
                .HasForeignKey(x => x.CharacterId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();


            modelBuilder.Entity<QuestEntry>()
                .HasOne(x => x.Quest)
                .WithMany(x => x.QuestEntries)
                .HasForeignKey(x => x.QuestId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            modelBuilder.Entity<QuestEntry>()
                .HasOne(x => x.Character)
                .WithMany(x => x.QuestEntries)
                .HasForeignKey(x => x.CharacterId)
                .IsRequired(false);
            modelBuilder.Entity<QuestEntry>()
                .HasOne(x => x.CreatedBy)
                .WithMany(x => x.QuestEntries)
                .HasForeignKey(x => x.CreatedById)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Forum>()
                .Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Forum>()
                .Property(x => x.Category).IsRequired();
            modelBuilder.Entity<Forum>()
                .HasOne(x => x.CreatedBy)
                .WithMany(x => x.CreatedForums)
                .HasForeignKey(x => x.CreatedById)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Forum>()
                .Property(x => x.Created)
                .IsRequired();
            modelBuilder.Entity<Forum>()
                .HasMany(x => x.AccessRights)
                .WithOne(x => x.Forum)
                .HasForeignKey(x => x.ForumId);

            modelBuilder.Entity<ForumRoleAccessRight>()
                .HasOne(x => x.Role)
                .WithMany(x => x.ForumRoleAccessRights)
                .HasForeignKey(x => x.RoleId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<ForumUserAccessRight>()
                .HasOne(x => x.User)
                .WithMany(x => x.ForumUserAccessRights)
                .HasForeignKey(x => x.UserId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<ForumEntry>()
                .HasOne(x => x.User)
                .WithMany(x => x.ForumEntries)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<ForumEntry>().Property(x => x.Created).IsRequired();
            modelBuilder.Entity<ForumEntry>().Property(x => x.Changed).IsRequired(false);

            modelBuilder.Entity<ForumEntry>()
                .HasOne(x => x.Forum)
                .WithMany(x => x.ForumEntries)
                .HasForeignKey(x => x.ForumId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
