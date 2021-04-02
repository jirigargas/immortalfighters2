using System.Collections.Generic;

namespace ImmortalFighters.WebApp.Models
{
    public abstract class Character
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Avatar { get; set; }
        public CharacterStatus Status {get;set;}
        public ICollection<QuestCharacter> QuestCharacters { get; set; }
        public ICollection<QuestEntry> QuestEntries { get; set; }
        public ICollection<CharacterEquipment> Vybaveni { get; set; }
    }

    public enum CharacterStatus
    {
        Active,
        Dead,
        Deleted
    }

    public class DrdCharacter : Character
    {
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
    }

    public enum DrdPresvedceni
    {
        ZakonneDobro,
        ZmateneDobro,
        Neutralni,
        ZmateneZlo,
        ZakonneZlo
    }

    public class Drd2Character : Character
    {
        public Drd2Rasa Rasa { get; set; }
    }

    public enum DrdRasa 
    {
        Hobit,
        Kuduk,
        Trpaslik,
        Elf,
        Clovek,
        Barbar,
        Kroll
    }
    
    public enum Drd2Rasa
    {
        Clovek,
        Elf,
        Trpaslik,
        Hobit,
        Kroll
    }

    public enum DrdPovolani
    {
        Valecnik,
        Bojovnik,
        Sermir,
        Hranicar,
        Druid,
        Chodec,
        Alchymista,
        Theurg,
        Pyrofor,
        Kouzelnik,
        Mag,
        Carodej,
        Zlodej,
        Lupic,
        Sicco
    }
}
