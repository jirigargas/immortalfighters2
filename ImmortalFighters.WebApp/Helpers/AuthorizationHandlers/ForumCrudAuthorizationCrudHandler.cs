using ImmortalFighters.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ImmortalFighters.WebApp.Helpers.AuthorizationHandlers
{
    public class ForumCrudAuthorizationCrudHandler : AuthorizationHandler<OperationAuthorizationRequirement, Forum>
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public ForumCrudAuthorizationCrudHandler(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, Forum resource)
        {
            var user = _contextAccessor.HttpContext.Items[Consts.HttpContextUser] as User;

            if (requirement.Name == Operations.Read.Name
                && resource.CanUserPerformOperation(user, x => x.CanRead))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
