namespace SkiResorts.Services.Implementations
{
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private readonly SkiResortsDbContext db;

        public UserService(SkiResortsDbContext db)
        {
            this.db = db;
        }

        public async Task<User> GetUserAsync(string id)
            => await this.db.Users.FirstOrDefaultAsync(u => u.Id == id);

        public async Task<bool> UserHasResortAsync(string id)
             => await this.db.Users.AnyAsync(u => u.Resort != null && u.Id == id);
       
    }
}
