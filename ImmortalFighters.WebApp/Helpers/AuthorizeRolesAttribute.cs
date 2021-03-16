using ImmortalFighters.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ImmortalFighters.WebApp.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeRolesAttribute : Attribute, IAuthorizationFilter
    {
        public AuthorizeRolesAttribute(params string[] roles)
        {
            Roles = roles.ToList();
            if (!Roles.Contains(Consts.RoleAdmin)) 
                Roles.Add(Consts.RoleAdmin); // admin has access everywhere
        }

        public List<string> Roles { get; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.Items["User"] as User;

            if (user == null || !HasCorrectRole(user))
            {
                // not logged in
                context.Result = new JsonResult(new { message = "Forbidden" })
                {
                    StatusCode = StatusCodes.Status403Forbidden
                };
            }
        }

        private bool HasCorrectRole(User user)
        {
            return user.UserRoles
                .Select(x => x.Role.Name)
                .Intersect(Roles)
                .Any();
        }
    }
}
