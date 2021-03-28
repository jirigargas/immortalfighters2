using ImmortalFighters.WebApp.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ImmortalFighters.WebApp.Models.Seed
{
    public class UserSeeder : ISeeder
    {
        private readonly IServiceProvider serviceProvider;

        public UserSeeder(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task Seed()
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<IfDbContext>();
                var userRepository = scope.ServiceProvider.GetService<IUserRepository>();

                var admin = context.Users.FirstOrDefault(x => x.Username == "admin");
                if (admin == null) admin = await userRepository.Register(new ApiModels.RegisterRequest { Username = "admin", Email = "admin@admin", Password = "password" });

                var adminRoleId = context.Roles.Single(x => x.Name == Consts.RoleAdmin).RoleId;
                var adminHasAdminRole = context.UserRoles.Any(x => x.RoleId == adminRoleId && x.UserId == admin.UserId);
                if (!adminHasAdminRole) context.UserRoles.Add(new UserRole { RoleId = adminRoleId, UserId = admin.UserId });

                await context.SaveChangesAsync();
            }

        }
    }
}
