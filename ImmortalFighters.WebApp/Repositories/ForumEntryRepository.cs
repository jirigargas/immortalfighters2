using ImmortalFighters.WebApp.ApiModels;
using ImmortalFighters.WebApp.Helpers;
using ImmortalFighters.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ImmortalFighters.WebApp.Services
{
    public interface IForumEntryRepository
    {
        Task<ForumEntry> Create(CreateNewForumEntryRequest request);
    }

    public class ForumEntryRepository : IForumEntryRepository
    {
        private readonly IfDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ForumEntryRepository(IfDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ForumEntry> Create(CreateNewForumEntryRequest request)
        {
            var forum = await _context.Forums.Include(x => x.AccessRights).SingleAsync(x => x.ForumId == request.ForumId);
            var user = _httpContextAccessor.HttpContext.Items[Consts.HttpContextUser] as User;

            if (!CanUserWriteToForum(user, forum)) throw new ApiResponseException { StatusCode = 403 };

            var newEntry = new ForumEntry
            {
                Forum = forum,
                User = user,
                Created = DateTime.UtcNow,
                Status = ForumEntryStatus.Active,
                Text = request.Text
            };

            _context.ForumEntries.Add(newEntry);
            _context.SaveChanges();
            return newEntry;
        }

        private bool CanUserWriteToForum(User user, Forum forum)
        {
            var userRoleIds = user.UserRoles.Select(x => x.RoleId);
            var userIsAdmin = user.UserRoles.Any(x => x.Role.Name == Consts.RoleAdmin);
            var canWriteToForumByRoleAccessRight = forum.AccessRights
                .OfType<ForumRoleAccessRight>()
                .Where(x => x.CanWrite)
                .Select(x => x.RoleId)
                .Intersect(userRoleIds)
                .Any();

            var canWriteToForumByUserAccessRight = forum.AccessRights
                .OfType<ForumUserAccessRight>()
                .Any(x => x.UserId == user.UserId && x.CanWrite);

            return userIsAdmin || canWriteToForumByRoleAccessRight || canWriteToForumByUserAccessRight;
        }
    }
}
