using ImmortalFighters.WebApp.Models;
using System;

namespace ImmortalFighters.WebApp.Services
{

    public class DrdCharacterCreatorClassTable
    {
        private Random _random;

        public DrdCharacterCreatorClassTable()
        {
            _random = new Random();
        }

        public int? GetStrength(DrdPovolani _class)
        {
            if (_class == DrdPovolani.Valecnik)
            {
                return _random.Next(16, 19);
            }

            if (_class == DrdPovolani.Hranicar)
            {
                return _random.Next(11, 17);
            }

            return null;
        }

        public int? GetDexterity(DrdPovolani _class)
        {
            if (_class == DrdPovolani.Alchymista)
            {
                return _random.Next(13, 19);
            }

            if (_class == DrdPovolani.Zlodej)
            {
                return _random.Next(14, 20);
            }

            return null;
        }

        public int? GetEndurance(DrdPovolani _class)
        {
            if (_class == DrdPovolani.Valecnik)
            {
                return _random.Next(13, 19);
            }

            if (_class == DrdPovolani.Alchymista)
            {
                return _random.Next(12, 18);
            }

            return null;
        }

        public int? GetIntelligence(DrdPovolani _class)
        {
            if (_class == DrdPovolani.Hranicar)
            {
                return _random.Next(12, 18);
            }

            if (_class == DrdPovolani.Kouzelnik)
            {
                return _random.Next(14, 20);
            }

            return null;
        }

        public int? GetCharisma(DrdPovolani _class)
        {
            if (_class == DrdPovolani.Kouzelnik)
            {
                return _random.Next(13, 19);
            }

            if (_class == DrdPovolani.Zlodej)
            {
                return _random.Next(12, 18);
            }

            return null;
        }
    }

    public class DrdCharacterCreatorRaceTable
    {
        private Random _random;

        public DrdCharacterCreatorRaceTable()
        {
            _random = new Random();
        }

        public int GetStrength(DrdRasa race)
        {
            switch (race)
            {
                case DrdRasa.Hobit:
                    return _random.Next(3, 9);
                case DrdRasa.Kuduk:
                    return _random.Next(5, 11);
                case DrdRasa.Trpaslik:
                    return _random.Next(7, 13);
                case DrdRasa.Elf:
                    return _random.Next(6, 12);
                case DrdRasa.Clovek:
                    return _random.Next(6, 17);
                case DrdRasa.Barbar:
                    return _random.Next(10, 16);
                case DrdRasa.Kroll:
                    return _random.Next(11, 17);
                default:
                    throw new NotImplementedException();
            }
        }

        public int GetDexterity(DrdRasa race)
        {
            switch (race)
            {
                case DrdRasa.Hobit:
                    return _random.Next(11, 17);
                case DrdRasa.Kuduk:
                    return _random.Next(10, 16);
                case DrdRasa.Trpaslik:
                    return _random.Next(7, 13);
                case DrdRasa.Elf:
                    return _random.Next(10, 16);
                case DrdRasa.Clovek:
                    return _random.Next(9, 15);
                case DrdRasa.Barbar:
                    return _random.Next(8, 14);
                case DrdRasa.Kroll:
                    return _random.Next(5, 11);
                default:
                    throw new NotImplementedException();
            }
        }

        public int GetEndurance(DrdRasa race)
        {
            switch (race)
            {
                case DrdRasa.Hobit:
                    return _random.Next(8, 14);
                case DrdRasa.Kuduk:
                    return _random.Next(10, 16);
                case DrdRasa.Trpaslik:
                    return _random.Next(12, 18);
                case DrdRasa.Elf:
                    return _random.Next(6, 12);
                case DrdRasa.Clovek:
                    return _random.Next(9, 15);
                case DrdRasa.Barbar:
                    return _random.Next(11, 17);
                case DrdRasa.Kroll:
                    return _random.Next(13, 19);
                default:
                    throw new NotImplementedException();
            }
        }

        public int GetIntelligence(DrdRasa race)
        {
            switch (race)
            {
                case DrdRasa.Hobit:
                    return _random.Next(10, 16);
                case DrdRasa.Kuduk:
                    return _random.Next(9, 15);
                case DrdRasa.Trpaslik:
                    return _random.Next(8, 14);
                case DrdRasa.Elf:
                    return _random.Next(12, 18);
                case DrdRasa.Clovek:
                    return _random.Next(10, 16);
                case DrdRasa.Barbar:
                    return _random.Next(6, 12);
                case DrdRasa.Kroll:
                    return _random.Next(2, 8);
                default:
                    throw new NotImplementedException();
            }
        }

        public int GetCharisma(DrdRasa race)
        {
            switch (race)
            {
                case DrdRasa.Hobit:
                    return _random.Next(8, 19);
                case DrdRasa.Kuduk:
                    return _random.Next(7, 13);
                case DrdRasa.Trpaslik:
                    return _random.Next(7, 13);
                case DrdRasa.Elf:
                    return _random.Next(8, 19);
                case DrdRasa.Clovek:
                    return _random.Next(2, 18);
                case DrdRasa.Barbar:
                    return _random.Next(1, 17);
                case DrdRasa.Kroll:
                    return _random.Next(1, 12);
                default:
                    throw new NotImplementedException();
            }
        }

    }

    public class DrdCharacterCreatorCorrectionTable
    {
        public int GetStrength(DrdRasa race)
        {
            switch (race)
            {
                case DrdRasa.Hobit:
                    return -5;
                case DrdRasa.Kuduk:
                    return -3;
                case DrdRasa.Trpaslik:
                    return +1;
                case DrdRasa.Elf:
                    return 0;
                case DrdRasa.Clovek:
                    return 0;
                case DrdRasa.Barbar:
                    return +1;
                case DrdRasa.Kroll:
                    return +3;
                default:
                    throw new NotImplementedException();
            }
        }

        public int GetDexterity(DrdRasa race)
        {
            switch (race)
            {
                case DrdRasa.Hobit:
                    return +2;
                case DrdRasa.Kuduk:
                    return +1;
                case DrdRasa.Trpaslik:
                    return -2;
                case DrdRasa.Elf:
                    return +1;
                case DrdRasa.Clovek:
                    return 0;
                case DrdRasa.Barbar:
                    return -1;
                case DrdRasa.Kroll:
                    return -4;
                default:
                    throw new NotImplementedException();
            }
        }

        public int GetEndurance(DrdRasa race)
        {
            switch (race)
            {
                case DrdRasa.Hobit:
                    return 0;
                case DrdRasa.Kuduk:
                    return +1;
                case DrdRasa.Trpaslik:
                    return +3;
                case DrdRasa.Elf:
                    return -4;
                case DrdRasa.Clovek:
                    return 0;
                case DrdRasa.Barbar:
                    return +1;
                case DrdRasa.Kroll:
                    return +3;
                default:
                    throw new NotImplementedException();
            }
        }

        public int GetIntelligence(DrdRasa race)
        {
            switch (race)
            {
                case DrdRasa.Hobit:
                    return -2;
                case DrdRasa.Kuduk:
                    return -2;
                case DrdRasa.Trpaslik:
                    return -3;
                case DrdRasa.Elf:
                    return +2;
                case DrdRasa.Clovek:
                    return 0;
                case DrdRasa.Barbar:
                    return 0;
                case DrdRasa.Kroll:
                    return -6;
                default:
                    throw new NotImplementedException();
            }
        }

        public int GetCharisma(DrdRasa race)
        {
            switch (race)
            {
                case DrdRasa.Hobit:
                    return +3;
                case DrdRasa.Kuduk:
                    return 0;
                case DrdRasa.Trpaslik:
                    return -2;
                case DrdRasa.Elf:
                    return +2;
                case DrdRasa.Clovek:
                    return 0;
                case DrdRasa.Barbar:
                    return -2;
                case DrdRasa.Kroll:
                    return -5;
                default:
                    throw new NotImplementedException();
            }
        }
    }

    public class DrdCharacterCreatorBasicLivesTable
    {
        public int GetBasicLives(DrdPovolani @class)
        {
            switch (@class)
            {
                case DrdPovolani.Valecnik:
                    return 10;
                case DrdPovolani.Hranicar:
                    return 8;
                case DrdPovolani.Alchymista:
                    return 7;
                case DrdPovolani.Kouzelnik:
                    return 6;
                case DrdPovolani.Zlodej:
                    return 6;
                default:
                    throw new NotImplementedException();
            }
        }
    }

    public interface IDrdCharacterCreator
    {
        int GetStrength(DrdRasa race, DrdPovolani @class);
        int GetDexterity(DrdRasa race, DrdPovolani @class);
        int GetEndurance(DrdRasa race, DrdPovolani @class);
        int GetIntelligence(DrdRasa race, DrdPovolani @class);
        int GetCharisma(DrdRasa race, DrdPovolani @class);
        int GetLives(DrdPovolani @class, int endurance);
    }

    public class DrdCharacterCreator : IDrdCharacterCreator
    {
        private readonly DrdCharacterCreatorClassTable _classTable;
        private readonly DrdCharacterCreatorRaceTable _raceTable;
        private readonly DrdCharacterCreatorCorrectionTable _correctionTable;
        private readonly DrdCharacterCreatorBasicLivesTable _basicLivesTable;
        private readonly IDrdBonusOrPenaltyService _bonusOrPenaltyService;

        public DrdCharacterCreator(IDrdBonusOrPenaltyService bonusOrPenaltyService)
        {
            _classTable = new DrdCharacterCreatorClassTable();
            _raceTable = new DrdCharacterCreatorRaceTable();
            _correctionTable = new DrdCharacterCreatorCorrectionTable();
            _basicLivesTable = new DrdCharacterCreatorBasicLivesTable();
            _bonusOrPenaltyService = bonusOrPenaltyService;
        }

        public int GetCharisma(DrdRasa race, DrdPovolani @class)
        {
            var valueByClass = _classTable.GetCharisma(@class);
            if (valueByClass.HasValue)
            {
                return valueByClass.Value + _correctionTable.GetCharisma(race);
            }
            else
            {
                return _raceTable.GetCharisma(race);
            }
        }

        public int GetDexterity(DrdRasa race, DrdPovolani @class)
        {
            var valueByClass = _classTable.GetDexterity(@class);
            if (valueByClass.HasValue)
            {
                return valueByClass.Value + _correctionTable.GetDexterity(race);
            }
            else
            {
                return _raceTable.GetDexterity(race);
            }
        }

        public int GetEndurance(DrdRasa race, DrdPovolani @class)
        {
            var valueByClass = _classTable.GetEndurance(@class);
            if (valueByClass.HasValue)
            {
                return valueByClass.Value + _correctionTable.GetEndurance(race);
            }
            else
            {
                return _raceTable.GetEndurance(race);
            }
        }

        public int GetIntelligence(DrdRasa race, DrdPovolani @class)
        {
            var valueByClass = _classTable.GetIntelligence(@class);
            if (valueByClass.HasValue)
            {
                return valueByClass.Value + _correctionTable.GetIntelligence(race);
            }
            else
            {
                return _raceTable.GetIntelligence(race);
            }
        }

        public int GetLives(DrdPovolani @class, int endurance)
        {
            return _basicLivesTable.GetBasicLives(@class) + _bonusOrPenaltyService.GetBonusOrPenalty(endurance);
        }

        public int GetStrength(DrdRasa race, DrdPovolani @class)
        {
            var valueByClass = _classTable.GetStrength(@class);
            if (valueByClass.HasValue)
            {
                return valueByClass.Value + _correctionTable.GetStrength(race);
            }
            else
            {
                return _raceTable.GetStrength(race);
            }
        }
    }
}
