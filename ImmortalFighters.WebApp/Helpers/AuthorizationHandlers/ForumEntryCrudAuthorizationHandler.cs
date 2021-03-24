using ImmortalFighters.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ImmortalFighters.WebApp.Helpers.AuthorizationHandlers
{
    public class ForumEntryCrudAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, ForumEntry>
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public ForumEntryCrudAuthorizationHandler(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, ForumEntry resource)
        {
            var user = _contextAccessor.HttpContext.Items[Consts.HttpContextUser] as User;

            if (requirement.Name == Operations.Create.Name
                && resource.Forum.CanUserPerformOperation(user, x => x.CanWrite))
            {
                context.Succeed(requirement);
            }

            if (requirement.Name == Operations.Delete.Name && resource.User == user)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }

    }
}
