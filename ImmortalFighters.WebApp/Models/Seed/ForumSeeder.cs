using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImmortalFighters.WebApp.Models.Seed
{
    public class ForumSeeder : ISeeder
    {
        private readonly IServiceProvider serviceProvider;

        public ForumSeeder(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task Seed()
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<IfDbContext>();
                var admin = context.Users.First(x => x.Username == "admin");

                var generalForum = context.Forums.FirstOrDefault(x => x.Name == "Obecné forum");
                if (generalForum == null)
                {
                    var newForum = new Forum
                    {
                        Name = "Obecné forum",
                        Category = "Pro všechny",
                        Created = DateTime.UtcNow,
                        CreatedBy = context.Users.First(),
                        Status = ForumStatus.Active,
                    };

                    context.Forums.Add(newForum);

                    foreach (var role in context.Roles)
                    {
                        context.AccessRights.Add(new ForumRoleAccessRight { CanRead = true, CanWrite = true, Forum = newForum, Role = role });
                    }

                    for(int i = 0; i < 1000; i++)
                    {
                        context.ForumEntries.Add(new ForumEntry() { Created = DateTime.UtcNow, Forum = newForum, Status = ForumEntryStatus.Active, User = admin, Text = "{\"ops\":[{\"insert\":\"ahoj\\n\"}]}" });
                    }
                }

                var adminForum = context.Forums.FirstOrDefault(x => x.Name == "Pro adminy");
                if (adminForum == null)
                {
                    var newForum = new Forum
                    {
                        Name = "Pro adminy",
                        Category = "Tajné",
                        Created = DateTime.UtcNow,
                        CreatedBy = context.Users.First(),
                        Status = ForumStatus.Active,
                    };

                    context.Forums.Add(newForum);
                    var adminRole = context.Roles.Single(x => x.Name == Consts.RoleAdmin);
                    context.AccessRights.Add(new ForumRoleAccessRight { CanRead = true, CanWrite = true, Forum = newForum, Role = adminRole });

                    foreach (var role in context.Roles.Where(x => x.RoleId != adminRole.RoleId))
                    {
                        context.AccessRights.Add(new ForumRoleAccessRight { CanRead = false, CanWrite = false, Forum = newForum, Role = role });
                    }
                }

                await context.SaveChangesAsync();
            }
        }
    }
}
