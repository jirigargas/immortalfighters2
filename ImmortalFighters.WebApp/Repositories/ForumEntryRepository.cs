using ImmortalFighters.WebApp.Models;
using System;
using System.Linq;

namespace ImmortalFighters.WebApp.Services
{
    public interface IForumEntryRepository
    {
        ForumEntry Create(int forumId, int userId, string text);
        ForumEntry GetById(int forumEntryId);
        IQueryable<ForumEntry> GetPage(int forumId, int page, int pageSize);
        int Count(int forumId);
        ForumEntry Delete(int forumEntryId);
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

        public ForumEntry Create(int forumId, int userId, string text)
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

        public ForumEntry Delete(int forumEntryId)
        {
            var forumEntry = _context.ForumEntries.Find(forumEntryId);
            forumEntry.Status = ForumEntryStatus.Deleted;
            _context.SaveChanges();
            return forumEntry;
        }

        public ForumEntry GetById(int forumEntryId)
        {
            return _context.ForumEntries.Find(forumEntryId);
        }

        public IQueryable<ForumEntry> GetPage(int forumId, int page, int pageSize)
        {
            return _context.ForumEntries
                .Where(x => x.ForumId == forumId)
                .Where(x => x.Status == ForumEntryStatus.Active)
                .OrderByDescending(x => x.Created)
                .Skip(pageSize * page)
                .Take(pageSize);
        }
    }
}
