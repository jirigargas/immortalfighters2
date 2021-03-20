using ImmortalFighters.WebApp.ApiModels;
using ImmortalFighters.WebApp.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ImmortalFighters.WebApp.Services
{
    public interface IForumRepository
    {
        IEnumerable<Forum> GetAll();
        IEnumerable<string> GetAllCategories();
        Forum Create(CreateNewForumRequest request);
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
                CreatedBy = (User)_httpContextAccessor.HttpContext.Items["User"],
                Status = ForumStatus.Active
            };
            // TODO Add accessRights!
            _context.Forums.Add(newForum);
            _context.SaveChanges();
            return newForum;
        }

        public IEnumerable<Forum> GetAll()
        {
            return _context.Forums.Select(x => x);
        }

        public IEnumerable<string> GetAllCategories()
        {
            return _context.Forums.Select(x => x.Category).Distinct();
        }
    }
}
