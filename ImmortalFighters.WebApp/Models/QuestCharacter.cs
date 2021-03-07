namespace ImmortalFighters.WebApp.Models
{
    public class QuestCharacter
    {
        public int QuestId { get; set; }
        public Quest Quest { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; }
    }
}
