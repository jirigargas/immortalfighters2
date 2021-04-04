using ImmortalFighters.WebApp.Models;

namespace ImmortalFighters.WebApp.ApiModels
{
    public class DrdCharacterDetailResponse
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public DrdRasa Rasa { get; set; }
        public DrdPovolani Povolani { get; set; }
        public int Sila { get; set; }
        public int Obratnost { get; set; }
        public int Odolnost { get; set; }
        public int Inteligence { get; set; }
        public int Charisma { get; set; }
        public int Zivoty { get; set; }
        public int Zkusenosti { get; set; }
        public int Uroven { get; set; }
        public DrdPresvedceni Presvedceni { get; set; }
        public string Avatar { get; set; }
    }
}
