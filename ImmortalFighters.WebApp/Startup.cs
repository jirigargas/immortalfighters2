using ImmortalFighters.WebApp.Helpers;
using ImmortalFighters.WebApp.Middlewares;
using ImmortalFighters.WebApp.Models;
using ImmortalFighters.WebApp.Repositories;
using ImmortalFighters.WebApp.Services;
using ImmortalFighters.WebApp.Settings;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ImmortalFighters.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews(options => options.Filters.Add(new ApiResponseExceptionFilter()));
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
            services.AddMediatR(typeof(Startup));
            services.AddDbContext<IfDbContext>(x => x.UseSqlServer(
                Configuration.GetConnectionString("If"),
                providerOptions => { providerOptions.EnableRetryOnFailure(); }
                ));

            services.Configure<SecurityOptions>(options => Configuration.GetSection("Security").Bind(options));
            services.Configure<SmtpOptions>(options => Configuration.GetSection("Smtp").Bind(options));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IForumRepository, ForumRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IForumEntryRepository, ForumEntryRepository>();

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IAuthenticationProvider, AuthenticationProvider>();
            services.AddScoped<IForumEntryService, ForumEntryService>();

            // imperative authorization
            services.AddAuthorization();
            services.AddTransient<IAuthorizationHandler, ForumEntryAuthorizationCrudHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IfDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseMiddleware<AuthenticationMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                }
            });

            // migrate any database changes on startup (includes initial db creation)
            dbContext.Database.Migrate();
        }
    }
}
