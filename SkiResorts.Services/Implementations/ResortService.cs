namespace SkiResorts.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models.Resorts;
    using SkiResorts.Common.Mapping;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ResortService : IResortService
    {
        private readonly SkiResortsDbContext db;
        private readonly IUserService userService;
        private readonly ILiftCardService liftCardService;

        public ResortService(SkiResortsDbContext db, IUserService userService, ILiftCardService liftCardService)
        {
            this.db = db;
            this.userService = userService;
            this.liftCardService = liftCardService;
        }

        public async Task<IEnumerable<ResortListingServiceModel>> All()
            => await this
                .db
                .Resorts
                .Include(r => r.Slopes)
                .Include(r => r.Lifts)
                .ProjectTo<ResortListingServiceModel>()
                .ToListAsync();

        public async void Create(string name, string ownerId)
        {
            var resort = new Resort
            {
                Name = name,
                OwnerId = ownerId
            };

            await db.Resorts.AddAsync(resort);
            db.SaveChanges();
        }

        public bool UserHasResort(string userId)
            => this
                .db
                .Resorts
                .Any(r => r.OwnerId == userId);

        public int GetResortIdOfUser(string userId)
        {
            if (!this.UserHasResort(userId))
            {
                return 0;
            }

            var resortId = this.db.Resorts.FirstOrDefaultAsync(r => r.OwnerId == userId).Result.Id;
            
            return resortId;
        }

        public async Task<bool> ResortExistsAsync(int id)
            => await this
                .db
                .Resorts
                .AnyAsync(r => r.Id == id);

        public async Task<ResortFormServiceModel> GetResortAsync(int id)
            => await this
                .db
                .Resorts
                .Where(r => r.Id == id)
                .ProjectTo<ResortFormServiceModel>()
                .FirstOrDefaultAsync();

        public async Task<Resort> GetResortFullModelAsync(int id)
            => await this
                .db
                .Resorts
                .FirstOrDefaultAsync(r => r.Id == id);

        public async Task EditResortAsync(string resortName, int id)
        {
            var resort = await this.GetResortFullModelAsync(id);

            if (resort == null)
            {
                return;
            }

            resort.Name = resortName;
            db.Entry(resort).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task DeleteResortAsync(int id)
        {
            var resort = await this.GetResortFullModelAsync(id);

            if (resort == null)
            {
                return;
            }

            await this.liftCardService.DeleteAllAsync(id);

            this.db.Resorts.Remove(resort);
            this.db.Entry(resort).State = EntityState.Deleted;
            await db.SaveChangesAsync();
        }

        public async Task<bool> IsResortOfUserAsync(int resortId, string username)
            => await db.Resorts.Include(r => r.Owner).AnyAsync(r => r.Id == resortId && r.Owner.UserName == username);

        public async Task<ResortWithFacilitiesServiceModel> GetResortWithFacilities(int id)
            => await this
                .db
                .Resorts
                .Where(r => r.Id == id)
                .ProjectTo<ResortWithFacilitiesServiceModel>()
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<ResortShortModel>> GetResortsForSelect()
            => await this
                .db
                .Resorts
                .ProjectTo<ResortShortModel>()
                .ToListAsync();
    }
}
