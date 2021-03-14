using ImmortalFighters.WebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ImmortalFighters.WebApp.Services
{
    public interface IForumService
    {
        IEnumerable<Forum> GetAll();
    }

    public class ForumService : IForumService
    {
        private readonly IfDbContext _context;

        public ForumService(IfDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Forum> GetAll()
        {
            return _context.Forums.Select(x => x);
        }
    }
}
