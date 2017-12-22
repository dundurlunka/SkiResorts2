namespace SkiResorts.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models.Admin;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AdminUserService : IAdminUserService
    {
        private readonly SkiResortsDbContext db;

        public AdminUserService(SkiResortsDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<UserListingServiceModel>> GetAllUsersAsync()
        {
            var users = await this
            .db
            .Users
            .Include(u => u.Resort)
            .Include(u => u.LiftCards)
            .ProjectTo<UserListingServiceModel>()
            .ToListAsync();

            return users;
        }
    }
}
