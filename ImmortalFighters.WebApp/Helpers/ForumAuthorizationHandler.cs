using ImmortalFighters.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ImmortalFighters.WebApp.Helpers
{
    /// <summary>
    /// ForumEntryAuthorizationCrudHandler authorize ForumEntry entity's CREATE / READ operations
    /// Creation of Forum entity is authorized by AuthorizeRole attribute.
    /// </summary>
    public class ForumEntryAuthorizationCrudHandler : AuthorizationHandler<OperationAuthorizationRequirement, Forum>
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public ForumEntryAuthorizationCrudHandler(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, Forum resource)
        {
            // TODO get rid of this, use claims instead
            var user = _contextAccessor.HttpContext.Items[Consts.HttpContextUser] as User;

            //var userId = context.User.Claims.FirstOrDefault(x=>x.Type==Services.ClaimTypes.Id);

            if (requirement.Name == Operations.Create.Name && CanUserPerformOperation(user, resource, x => x.CanWrite))
            {
                context.Succeed(requirement);
            }

            if (requirement.Name == Operations.Read.Name && CanUserPerformOperation(user, resource, x => x.CanRead))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }

        private bool CanUserPerformOperation(User user, Forum forum, Func<AccessRight, bool> operationFilter)
        {
            var userRoleIds = user.UserRoles.Select(x => x.RoleId);
            var userIsAdmin = user.UserRoles.Any(x => x.Role.Name == Consts.RoleAdmin);
            var canWriteToForumByRoleAccessRight = forum.AccessRights
                .OfType<ForumRoleAccessRight>()
                .Where(x => operationFilter(x))
                .Select(x => x.RoleId)
                .Intersect(userRoleIds)
                .Any();

            var canWriteToForumByUserAccessRight = forum.AccessRights
                .OfType<ForumUserAccessRight>()
                .Any(x => x.UserId == user.UserId && operationFilter(x));

            return userIsAdmin || canWriteToForumByRoleAccessRight || canWriteToForumByUserAccessRight;
        }
    }
}
