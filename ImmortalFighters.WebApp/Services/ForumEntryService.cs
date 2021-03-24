using AutoMapper;
using ImmortalFighters.WebApp.ApiModels;
using ImmortalFighters.WebApp.Helpers;
using ImmortalFighters.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace ImmortalFighters.WebApp.Services
{
    public interface IForumEntryService
    {
        Task<ForumEntriesResponse> GetForumEntries(int forumId, int page, int pageSize);
        Task<ForumEntryResponse> Create(CreateNewForumEntryRequest request);
        Task<ForumEntryResponse> Delete(int forumEntryId);
        Task<ForumEntryResponse> Update(UpdateForumEntryRequest request);
    }

    public class ForumEntryService : IForumEntryService
    {
        private readonly IMapper _mapper;
        private readonly IForumRepository _forumRepository;
        private readonly IForumEntryRepository _forumEntryRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthorizationService _authorizationService;

        public ForumEntryService(IMapper mapper,
            IForumRepository forumRepository,
            IForumEntryRepository forumEntryRepository,
            IHttpContextAccessor httpContextAccessor,
            IAuthorizationService authorizationService)
        {
            _mapper = mapper;
            _forumRepository = forumRepository;
            _forumEntryRepository = forumEntryRepository;
            _httpContextAccessor = httpContextAccessor;
            _authorizationService = authorizationService;
        }

        public async Task<ForumEntryResponse> Create(CreateNewForumEntryRequest request)
        {
            var forum = await _forumRepository.GetByIdWithAccessRights(request.ForumId);
            var authorization = await _authorizationService.AuthorizeAsync(_httpContextAccessor.HttpContext.User, new ForumEntry { Forum = forum }, Operations.Create);

            if (!authorization.Succeeded) throw new ApiResponseException { StatusCode = 403 };

            var user = _httpContextAccessor.HttpContext.Items[Consts.HttpContextUser] as User;
            var result = _forumEntryRepository.Create(request.ForumId, user.UserId, request.Text);

            var response = _mapper.Map<ForumEntryResponse>(result);
            return response;
        }

        public async Task<ForumEntryResponse> Delete(int forumEntryId)
        {
            var forumEntry = _forumEntryRepository.GetById(forumEntryId);
            var authorization = await _authorizationService.AuthorizeAsync(_httpContextAccessor.HttpContext.User, forumEntry, Operations.Delete);
            if (!authorization.Succeeded) throw new ApiResponseException { StatusCode = 403 };

            var result = _forumEntryRepository.Delete(forumEntryId);
            var response = _mapper.Map<ForumEntryResponse>(result);
            return response;
        }

        public async Task<ForumEntriesResponse> GetForumEntries(int forumId, int page, int pageSize)
        {
            var forum = await _forumRepository.GetByIdWithAccessRights(forumId);
            var authorization = await _authorizationService.AuthorizeAsync(_httpContextAccessor.HttpContext.User, forum, Operations.Read);

            if (!authorization.Succeeded) throw new ApiResponseException { StatusCode = 403 };

            var total = _forumEntryRepository.Count(forumId);
            var result = _forumEntryRepository.GetPage(forumId, page, pageSize)
                .AsEnumerable()
                .Select(x => _mapper.Map<ForumEntryResponse>(x));

            return new ForumEntriesResponse
            {
                Page = page,
                TotalCount = total,
                ForumEntries = result
            };
        }

        public async Task<ForumEntryResponse> Update(UpdateForumEntryRequest request)
        {
            var forumEntry = _forumEntryRepository.GetById(request.ForumEntryId);
            var authorization = await _authorizationService.AuthorizeAsync(_httpContextAccessor.HttpContext.User, forumEntry, Operations.Update);

            if (!authorization.Succeeded) throw new ApiResponseException { StatusCode = 403 };

            var result = _forumEntryRepository.Update(request.ForumEntryId, request.Text);

            var response = _mapper.Map<ForumEntryResponse>(result);
            return response;
        }
    }
}
