namespace ImmortalFighters.WebApp.Models
{
    public class Character
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public QuestCharacter QuestCharacters { get; set; }
    }
}
