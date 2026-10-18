using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace PolyCharge_DAT.Data
{
    public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // For sample purposes seed both with the same password.
                // Password is set with the following:
                // dotnet user-secrets set SeedUserPW <pw>
                // The admin user can do anything

                var adminID = await EnsureUser(serviceProvider, "PolyCharge@123", "admin@polycharge.com");
                await EnsureRole(serviceProvider, adminID, "admin");

                // allowed user can create and edit contacts that they create
                var managerID = await EnsureUser(serviceProvider, "PolyCharge@123", "manager@polycharge.com");
                await EnsureRole(serviceProvider, managerID, "manager");

                // create initial polycharge users
                var userID = await EnsureUser(serviceProvider, "NovaPC9456#", "wfrost@polycharge.com");
                await EnsureRole(serviceProvider, userID, "client");

                userID = await EnsureUser(serviceProvider, "JbnMdfNH2#", "yializis@polycharge.com");
                await EnsureRole(serviceProvider, userID, "client");

                userID = await EnsureUser(serviceProvider, "p9tGha8U3#", "rbullock@polycharge.com");
                await EnsureRole(serviceProvider, userID, "client");

                userID = await EnsureUser(serviceProvider, "2zmXZALz4#", "chohmann@sigmalabs.com");
                await EnsureRole(serviceProvider, userID, "client");

                userID = await EnsureUser(serviceProvider, "UvYhGkwt5#", "aberdun@polycharge.com");
                await EnsureRole(serviceProvider, userID, "client");

                userID = await EnsureUser(serviceProvider, "PQGfqDhq6#", "PRoop@polycharge.com");
                await EnsureRole(serviceProvider, userID, "client");

                // SeedDB(context, adminID);
            }
        }

        private static async Task<string> EnsureUser(IServiceProvider serviceProvider,
                                                    string testUserPw, string UserName)
        {
            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = UserName,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, testUserPw);
            }

            if (user == null)
            {
                throw new Exception("The password is probably not strong enough!");
            }

            return user.Id;
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider,
                                                                      string uid, string role)
        {
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (roleManager == null)
            {
                throw new Exception("roleManager null");
            }

            IdentityResult IR;
            if (!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            //if (userManager == null)
            //{
            //    throw new Exception("userManager is null");
            //}

            var user = await userManager.FindByIdAsync(uid);

            if (user == null)
            {
                throw new Exception("The testUserPw password was probably not strong enough!");
            }

            IR = await userManager.AddToRoleAsync(user, role);

            return IR;
        }
    }
}
