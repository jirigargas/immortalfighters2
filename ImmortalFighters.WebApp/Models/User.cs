using System;
using System.Collections.Generic;

namespace ImmortalFighters.WebApp.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastLoggedIn { get; set; }
        public AccountStatus Status { get; set; }
        public int UnsuccessfulLoginAttempts { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Character> Characters { get; set; }
        public ICollection<Quest> OrganizedQuests { get; set; }
        public ICollection<QuestEntry> QuestEntries { get; set; }
    }

    public enum AccountStatus
    {
        NotVerified,    // user has not verified email address
        Active,         // user has verified email address, account is now active
        Removed,        // account has been deleted
        Locked,         // too many login attempts were unsuccessful, user has to unlock account
        Banned          // there is active ban on the account
    }
}
