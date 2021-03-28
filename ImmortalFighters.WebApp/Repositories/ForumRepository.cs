using ImmortalFighters.WebApp.ApiModels;
using ImmortalFighters.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImmortalFighters.WebApp.Services
{
    public interface IForumRepository
    {
        IEnumerable<Forum> GetAll();
        IEnumerable<Forum> GetAllAccessibleTo(User user);
        IEnumerable<string> GetAllCategories();
        Forum Create(CreateNewForumRequest request);
        Task<Forum> GetByIdWithAccessRights(int forumId);
    }

    public class ForumRepository : IForumRepository
    {
        private readonly IfDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ForumRepository(IfDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public Forum Create(CreateNewForumRequest request)
        {
            var newForum = new Forum
            {
                Name = request.Name,
                Category = request.Category,
                Created = DateTime.UtcNow,
                CreatedBy = (User)_httpContextAccessor.HttpContext.Items[Consts.HttpContextUser],
                Status = ForumStatus.Active
            };
            _context.Forums.Add(newForum);

            foreach (var accessRight in request.AccessRights)
            {
                var forumRoleAccessRight = new ForumRoleAccessRight
                {
                    Forum = newForum,
                    RoleId = accessRight.RoleId,
                    CanRead = accessRight.CanRead,
                    CanWrite = accessRight.CanWrite
                };
                _context.AccessRights.Add(forumRoleAccessRight);
            }

            var adminRoleAccessRight = new ForumRoleAccessRight
            {
                Forum = newForum,
                Role = _context.Roles.Single(x => x.Name == Consts.RoleAdmin),
                CanRead = true,
                CanWrite = true
            };
            _context.AccessRights.Add(adminRoleAccessRight);

            _context.SaveChanges();
            return newForum;
        }

        public IEnumerable<Forum> GetAll()
        {
            return _context.Forums.Select(x => x);
        }

        public IEnumerable<Forum> GetAllAccessibleTo(User user)
        {
            _context.Entry(user).Collection(x => x.ForumUserAccessRights).Load();

            var forums = _context.Forums.Include(x => x.AccessRights).AsEnumerable();
            var userRoleIds = user.UserRoles.Select(x => x.RoleId);

            return forums
                .Where(x => user.UserRoles.Select(x => x.Role.Name).Contains(Consts.RoleAdmin)
                || x.AccessRights.OfType<ForumRoleAccessRight>().Any(r => r.CanRead && userRoleIds.Contains(r.RoleId)
                || user.ForumUserAccessRights.Any(r => r.CanRead && r.ForumId == x.ForumId)));
        }

        public IEnumerable<string> GetAllCategories()
        {
            return _context.Forums.Select(x => x.Category).Distinct();
        }

        public Task<Forum> GetByIdWithAccessRights(int forumId)
        {
            return _context.Forums
                .Include(x => x.AccessRights)
                .SingleAsync(x => x.ForumId == forumId);
        }
    }
}
