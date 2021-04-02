using System;

namespace ImmortalFighters.WebApp.Services
{
    public interface IDrdBonusOrPenaltyService
    {
        int GetBonusOrPenalty(int value);
    }

    public class DrdBonusOrPenaltyService : IDrdBonusOrPenaltyService
    {
        public int GetBonusOrPenalty(int value)
        {
            if (value == 1) return -5;
            if (value >= 2 && value <= 3) return -4;
            if (value >= 4 && value <= 5) return -3;
            if (value >= 6 && value <= 7) return -2;
            if (value >= 8 && value <= 9) return -1;
            if (value >= 10 && value <= 12) return 0;
            if (value >= 13 && value <= 14) return +1;
            if (value >= 15 && value <= 16) return +2;
            if (value >= 17 && value <= 18) return +3;
            if (value >= 19 && value <= 20) return +4;
            if (value == 21) return +5;

            throw new NotImplementedException();
        }
    }
}
