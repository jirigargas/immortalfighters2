namespace ImmortalFighters.WebApp.Models
{
    public class CharacterEquipment
    {
        public int CharacterEquipmentId { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; }
        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }

    }
}
