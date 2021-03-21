using ImmortalFighters.WebApp.Services;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ImmortalFighters.WebApp.Middlewares
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserRepository userService, IAuthenticationProvider authenticationProvider)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                AttachUserToContext(context, userService, authenticationProvider, token);

            await _next(context);
        }

        private void AttachUserToContext(HttpContext context, IUserRepository userService, IAuthenticationProvider authenticationProvider, string token)
        {
            try
            {
                var claims = authenticationProvider.ValidateToken(token);
                var userId = int.Parse(claims.First(x => x.Type == Services.ClaimTypes.Id).Value);

                var tokenIdentity = new ClaimsIdentity(claims, "token");
                context.User.AddIdentity(tokenIdentity);

                // attach user to context on successful jwt validation
                context.Items[Consts.HttpContextUser] = userService.GetBy(x => x.UserId == userId);
            }
            catch
            {
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }
    }
}
