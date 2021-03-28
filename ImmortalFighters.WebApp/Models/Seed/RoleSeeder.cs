using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ImmortalFighters.WebApp.Models.Seed
{
    public class RoleSeeder : ISeeder
    {
        private readonly IServiceProvider serviceProvider;

        public RoleSeeder(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task Seed()
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<IfDbContext>();
                var admin = context.Roles.FirstOrDefault(x => x.Name == Consts.RoleAdmin);
                if (admin == null) context.Roles.Add(new Role { Name = Consts.RoleAdmin });

                var econom = context.Roles.FirstOrDefault(x => x.Name == Consts.RoleEconom);
                if (econom == null) context.Roles.Add(new Role { Name = Consts.RoleEconom });

                var moderator = context.Roles.FirstOrDefault(x => x.Name == Consts.RoleModerator);
                if (moderator == null) context.Roles.Add(new Role { Name = Consts.RoleModerator });

                var patron = context.Roles.FirstOrDefault(x => x.Name == Consts.RolePatron);
                if (patron == null) context.Roles.Add(new Role { Name = Consts.RolePatron });

                var player = context.Roles.FirstOrDefault(x => x.Name == Consts.RolePlayer);
                if (player == null) context.Roles.Add(new Role { Name = Consts.RolePlayer });

                var vip = context.Roles.FirstOrDefault(x => x.Name == Consts.RoleVip);
                if (vip == null) context.Roles.Add(new Role { Name = Consts.RoleVip });

                await context.SaveChangesAsync();
            }
                
        }
    }
}
