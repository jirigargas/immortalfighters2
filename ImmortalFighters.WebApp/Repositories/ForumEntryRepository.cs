using ImmortalFighters.WebApp.ApiModels;
using ImmortalFighters.WebApp.Helpers;
using ImmortalFighters.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
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
        private readonly IAuthorizationService _authorizationService;

        public ForumEntryRepository(IfDbContext context, IHttpContextAccessor httpContextAccessor, IAuthorizationService authorizationService)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _authorizationService = authorizationService;
        }

        public async Task<ForumEntry> Create(CreateNewForumEntryRequest request)
        {
            var forum = await _context.Forums.Include(x => x.AccessRights).SingleAsync(x => x.ForumId == request.ForumId);
            var user = _httpContextAccessor.HttpContext.Items[Consts.HttpContextUser] as User;

            // TODO Move authorization up? to service?
            var authorization = await _authorizationService.AuthorizeAsync(_httpContextAccessor.HttpContext.User, forum, Operations.Create);

            if (!authorization.Succeeded) throw new ApiResponseException { StatusCode = 403 };

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


    }
}
