namespace SkiResorts.Web.Infrastructure.Extensions
{
    using Data.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Threading.Tasks;

    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder UseDatabaseMigrations<T>(this IApplicationBuilder app) where T : DbContext
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<T>().Database.Migrate();

                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();

                Task
                    .Run(async () =>
                    {
                        var roles = new[]
                        {
                            WebConstants.AdministratorRole,
                            WebConstants.EventManagerRole,
                            WebConstants.ResortOwnerRole
                        };

                        foreach (var role in roles)
                        {
                            var roleExists = await roleManager.RoleExistsAsync(role);

                            if (!roleExists)
                            {
                                await roleManager.CreateAsync(new IdentityRole
                                {
                                    Name = role
                                });
                            }
                        }

                        var adminEmail = "admin@admin.com";
                        var adminUsername = "admin";

                        var adminUser = await userManager.FindByNameAsync(adminEmail);

                        if (adminUser == null)
                        {
                            var user = new User
                            {
                                Email = adminEmail,
                                UserName = adminUsername,
                            };

                            await userManager.CreateAsync(user, "admin");

                            await userManager.AddToRoleAsync(user, WebConstants.AdministratorRole);
                        }
                    })
                    .Wait();
            }

            return app;
        }
    }
}
