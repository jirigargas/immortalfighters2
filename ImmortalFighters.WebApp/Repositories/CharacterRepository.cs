using ImmortalFighters.WebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ImmortalFighters.WebApp.Repositories
{
    public interface ICharacterRepository
    {
        public IEnumerable<Character> GetByUserId(int userId);
        public DrdCharacter CreateCharacter(DrdCharacter drdCharacter);
    }

    public class CharacterRepository : ICharacterRepository
    {
        private readonly IfDbContext _context;

        public CharacterRepository(IfDbContext context)
        {
            _context = context;
        }

        public DrdCharacter CreateCharacter(DrdCharacter character)
        {
            _context.Characters.Add(character);
            _context.SaveChanges();
            return character;
        }

        public IEnumerable<Character> GetByUserId(int userId)
        {
            return _context.Characters.Where(x => x.UserId == userId);
        }
    }
}
