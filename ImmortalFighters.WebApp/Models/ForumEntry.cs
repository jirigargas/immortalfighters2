using System;

namespace ImmortalFighters.WebApp.Models
{
    public class ForumEntry
    {
        public int ForumEntryId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Changed { get; set; }
        public string Text { get; set; }
        public int ForumId { get; set; }
        public Forum Forum { get; set; }
        public ForumEntryStatus Status { get; set; }
    }

    public enum ForumEntryStatus
    {
        Active,
        Deleted
    }
}
