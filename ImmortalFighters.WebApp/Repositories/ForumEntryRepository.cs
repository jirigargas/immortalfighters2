using ImmortalFighters.WebApp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ImmortalFighters.WebApp.Services
{
    public interface IForumEntryRepository
    {
        Task<ForumEntry> Create(int forumId, int userId, string text);
        IQueryable<ForumEntry> Get(int forumId, int page, int pageSize);
        int Count(int forumId);
    }

    public class ForumEntryRepository : IForumEntryRepository
    {
        private readonly IfDbContext _context;

        public ForumEntryRepository(IfDbContext context)
        {
            _context = context;
        }

        public int Count(int forumId)
        {
            return _context.ForumEntries.Count(x => x.ForumId == forumId);
        }

        public async Task<ForumEntry> Create(int forumId, int userId, string text)
        {
            var forum = _context.Forums.Find(forumId);
            var user = _context.Users.Find(userId);

            var newEntry = new ForumEntry
            {
                Forum = forum,
                User = user,
                Created = DateTime.UtcNow,
                Status = ForumEntryStatus.Active,
                Text = text
            };

            _context.ForumEntries.Add(newEntry);
            _context.SaveChanges();
            return newEntry;
        }

        public IQueryable<ForumEntry> Get(int forumId, int page, int pageSize)
        {
            return _context.ForumEntries
                .Where(x => x.ForumId == forumId)
                .OrderByDescending(x => x.Created)
                .Skip(pageSize * page)
                .Take(pageSize);
        }
    }
}
