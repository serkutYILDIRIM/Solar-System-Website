using Microsoft.AspNetCore.Identity;
using SolarSystem.Data.Models;

namespace SolarSystem
{
    public class IdentityInitializer
    {
        public static void CreateAdmin(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            AppUser appUser = new AppUser
            {
                Name = "Serkut",
                SurName = "Yıldırım",
                UserName = "serkut"
            };
            if (userManager.FindByNameAsync("Serkut").Result == null)
            {
                var identityResult = userManager.CreateAsync(appUser, "serkut").Result;
            }
            if (roleManager.FindByNameAsync("Admin").Result == null)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Admin"
                };
                var identityResult = roleManager.CreateAsync(role).Result;

                var Result = userManager.AddToRoleAsync(appUser, role.Name).Result;
            }
        }
    }
}
