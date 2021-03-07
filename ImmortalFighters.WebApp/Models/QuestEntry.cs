using System;

namespace ImmortalFighters.WebApp.Models
{
    public class QuestEntry
    {
        public int QuestEntryId { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }

        public int QuestId { get; set; }
        public Quest Quest { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; }
    }
}
