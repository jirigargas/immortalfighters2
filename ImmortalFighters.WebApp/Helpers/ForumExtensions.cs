using ImmortalFighters.WebApp.Models;
using System;
using System.Linq;

namespace ImmortalFighters.WebApp.Helpers
{
    public static class ForumExtensions
    {
        public static bool CanUserPerformOperation(this Forum forum, User user, Func<AccessRight, bool> operationFilter)
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
