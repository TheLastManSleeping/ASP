using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SocialNetwork.Models;

public class RoleInitializer
{
    public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        string adminEmail = "admin@gmail.com";
        string password = "_Aa123456";
        if (await roleManager.FindByNameAsync("admin") == null)
        {
            await roleManager.CreateAsync(new IdentityRole("admin"));
        }
        if (await roleManager.FindByNameAsync("employee") == null)
        {
            await roleManager.CreateAsync(new IdentityRole("employee"));
        }
        if (await userManager.FindByEmailAsync(adminEmail) == null)
        {
            User admin = new User {Email = adminEmail, UserName = adminEmail, EmailConfirmed = true, BirthDay = "1", Name = "1", Surname = "1", Country = "1", Gender = "1"};
            IdentityResult result = await userManager.CreateAsync(admin, password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, "admin");
            }
        }
    }
}