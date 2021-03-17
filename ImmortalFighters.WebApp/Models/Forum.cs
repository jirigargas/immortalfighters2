using System;
using System.Collections.Generic;

namespace ImmortalFighters.WebApp.Models
{
    public class Forum
    {
        public int ForumId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int CreatedById { get; set; }
        public User CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public ForumStatus Status { get; set; }
        public ICollection<ForumAccessRight> AccessRights { get; set; }
        public ICollection<ForumEntry> ForumEntries { get; set; }
    }

    public enum ForumStatus
    {
        Active,
        Readonly,
        Deleted
    }
}
