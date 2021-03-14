﻿// <auto-generated />
using System;
using ImmortalFighters.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ImmortalFighters.WebApp.Migrations
{
    [DbContext(typeof(IfDbContext))]
    [Migration("20210314190356_forum")]
    partial class forum
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ImmortalFighters.WebApp.Models.Character", b =>
                {
                    b.Property<int>("CharacterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CharacterId");

                    b.HasIndex("UserId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("ImmortalFighters.WebApp.Models.Forum", b =>
                {
                    b.Property<int>("ForumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ForumId");

                    b.ToTable("Forums");
                });

            modelBuilder.Entity("ImmortalFighters.WebApp.Models.Quest", b =>
                {
                    b.Property<int>("QuestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DungeonMasterId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuestId");

                    b.HasIndex("DungeonMasterId");

                    b.ToTable("Quests");
                });

            modelBuilder.Entity("ImmortalFighters.WebApp.Models.QuestCharacter", b =>
                {
                    b.Property<int>("QuestId")
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.HasKey("QuestId", "CharacterId");

                    b.HasIndex("CharacterId");

                    b.ToTable("QuestCharacters");
                });

            modelBuilder.Entity("ImmortalFighters.WebApp.Models.QuestEntry", b =>
                {
                    b.Property<int>("QuestEntryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CharacterId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestId")
                        .HasColumnType("int");

                    b.HasKey("QuestEntryId");

                    b.HasIndex("CharacterId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("QuestId");

                    b.ToTable("QuestEntries");
                });

            modelBuilder.Entity("ImmortalFighters.WebApp.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ImmortalFighters.WebApp.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("LastLoggedIn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UnsuccessfulLoginAttempts")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ImmortalFighters.WebApp.Models.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("ImmortalFighters.WebApp.Models.Character", b =>
                {
                    b.HasOne("ImmortalFighters.WebApp.Models.User", "User")
                        .WithMany("Characters")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ImmortalFighters.WebApp.Models.Quest", b =>
                {
                    b.HasOne("ImmortalFighters.WebApp.Models.User", "DungeonMaster")
                        .WithMany("OrganizedQuests")
                        .HasForeignKey("DungeonMasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DungeonMaster");
                });

            modelBuilder.Entity("ImmortalFighters.WebApp.Models.QuestCharacter", b =>
                {
                    b.HasOne("ImmortalFighters.WebApp.Models.Character", "Character")
                        .WithMany("QuestCharacters")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ImmortalFighters.WebApp.Models.Quest", "Quest")
                        .WithMany("QuestCharacters")
                        .HasForeignKey("QuestId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Quest");
                });

            modelBuilder.Entity("ImmortalFighters.WebApp.Models.QuestEntry", b =>
                {
                    b.HasOne("ImmortalFighters.WebApp.Models.Character", "Character")
                        .WithMany("QuestEntries")
                        .HasForeignKey("CharacterId");

                    b.HasOne("ImmortalFighters.WebApp.Models.User", "CreatedBy")
                        .WithMany("QuestEntries")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ImmortalFighters.WebApp.Models.Quest", "Quest")
                        .WithMany("QuestEntries")
                        .HasForeignKey("QuestId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("CreatedBy");

                    b.Navigation("Quest");
                });

            modelBuilder.Entity("ImmortalFighters.WebApp.Models.UserRole", b =>
                {
                    b.HasOne("ImmortalFighters.WebApp.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ImmortalFighters.WebApp.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ImmortalFighters.WebApp.Models.Character", b =>
                {
                    b.Navigation("QuestCharacters");

                    b.Navigation("QuestEntries");
                });

            modelBuilder.Entity("ImmortalFighters.WebApp.Models.Quest", b =>
                {
                    b.Navigation("QuestCharacters");

                    b.Navigation("QuestEntries");
                });

            modelBuilder.Entity("ImmortalFighters.WebApp.Models.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("ImmortalFighters.WebApp.Models.User", b =>
                {
                    b.Navigation("Characters");

                    b.Navigation("OrganizedQuests");

                    b.Navigation("QuestEntries");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
