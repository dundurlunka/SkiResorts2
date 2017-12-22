namespace SkiResorts.Web.Infrastructure.Extensions
{
    using Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public static class UserManagerExtensions
    {
        public static async Task<User> GetUserAndResortByUsernameAsync(this UserManager<User> userManager, string username)
        {
            return await userManager.Users.Include(u => u.Resort).SingleOrDefaultAsync(x => x.UserName == username);
        }
    }
}
