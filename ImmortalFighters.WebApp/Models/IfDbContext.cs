﻿using Microsoft.EntityFrameworkCore;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>()
                .HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<UserRole>()
                .HasOne(x => x.User)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.UserId)
                .IsRequired();
            modelBuilder.Entity<UserRole>()
                .HasOne(x => x.Role)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.RoleId)
                .IsRequired();

            modelBuilder.Entity<Character>()
                .HasOne(x => x.User)
                .WithMany(x => x.Characters)
                .HasForeignKey(x => x.UserId)
                .IsRequired();

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
                .IsRequired();
            modelBuilder.Entity<QuestCharacter>()
                .HasOne(x => x.Character)
                .WithMany(x => x.QuestCharacters)
                .HasForeignKey(x => x.CharacterId)
                .IsRequired();

            modelBuilder.Entity<QuestEntry>()
                .HasOne(x => x.Quest)
                .WithMany(x => x.QuestEntries)
                .HasForeignKey(x => x.QuestId)
                .IsRequired();
            modelBuilder.Entity<QuestEntry>()
                .HasOne(x => x.Character)
                .WithMany(x => x.QuestEntries)
                .HasForeignKey(x => x.CharacterId);

        }
    }
}
