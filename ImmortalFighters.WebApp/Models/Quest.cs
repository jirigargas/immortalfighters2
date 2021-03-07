using System.Collections.Generic;

namespace ImmortalFighters.WebApp.Models
{
    public class Quest
    {
        public int QuestId { get; set; }
        public string Name { get; set; }
        public int DungeonMasterId { get; set; }
        public User DungeonMaster { get; set; }
        public ICollection<QuestCharacter> QuestCharacters { get; set; }
        public ICollection<QuestEntry> QuestEntries { get; set; }
    }
}
