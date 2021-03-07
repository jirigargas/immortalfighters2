using System.Collections.Generic;

namespace ImmortalFighters.WebApp.Models
{
    public class Character
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<QuestCharacter> QuestCharacters { get; set; }
        public ICollection<QuestEntry> QuestEntries { get; set; }
    }
}
