using ImmortalFighters.WebApp.Models;

namespace ImmortalFighters.WebApp.ApiModels
{
    public class CreateDrdCharacterRequest
    {
        public string Name { get; set; }
        public DrdRasa Race { get; set; }
        public DrdPovolani Class { get; set; }
        public DrdPresvedceni Conviction { get; set; }
    }
}
