namespace ImmortalFighters.WebApp.ApiModels
{
    public class CharacterResponse
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public Rules Rules { get; set; }
        public string Avatar { get; set; }
    }

    public enum Rules
    {
        DraciDoupe,
        DraciDoupe2
    }
}
