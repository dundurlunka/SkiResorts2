namespace SkiResorts.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using SkiResorts.Data.Models;
    using SkiResorts.Services.Models.Slopes;
    using System.Linq;
    using System.Threading.Tasks;

    public class SlopeService : ISlopeService
    {
        private readonly SkiResortsDbContext db;
        private readonly IResortService resortService;

        public SlopeService(SkiResortsDbContext db, IResortService resortService)
        {
            this.db = db;
            this.resortService = resortService;
        }

        public async Task CreateAsync(string name, int length, SlopeDifficulty slopeDifficulty, Status status, string userId)
        {
            var resortId = this.resortService.GetResortIdOfUser(userId);

            var slope = new Slope
            {
                Name = name,
                Length = length,
                Difficulty = slopeDifficulty,
                Status = status,
                ResortId = resortId
            };

            await this.db.Slopes.AddAsync(slope);
            db.SaveChanges();
        }

        public async Task<bool> SlopeExistsAsync(int id) => await db.Slopes.AnyAsync(s => s.Id == id);

        public async Task<SlopeFormServiceModel> GetSlopeFormModelAsync(int id)
        {
            return await this.db.Slopes.Where(s => s.Id == id).ProjectTo<SlopeFormServiceModel>().FirstOrDefaultAsync();
        }

        public async Task<Slope> GetSlopeAsync(int id)
            => await this.db.Slopes.Where(s => s.Id == id).FirstOrDefaultAsync();

        public async Task DeleteSlopeAsync(int id)
        {
            var slope = await this.GetSlopeAsync(id);

            if (slope == null)
            {
                return;
            }
            
           db.Slopes.Remove(slope);
            await db.SaveChangesAsync();
        }

        public async Task<bool> IsSlopeOfUserAsync(int slopeId, string username)
            => await db.
                Slopes
                .Include(s => s.Resort)
                .AnyAsync(s => s.Id == slopeId && s.Resort.Owner.UserName == username);

        public async Task<bool> EditAsync(string name, int length, SlopeDifficulty slopeDifficulty, Status status, int slopeId)
        {
            var slope = await this.GetSlopeAsync(slopeId);

            if (slope == null)
            {
                return false;
            }

            slope.Name = name;
            slope.Length = length;
            slope.Difficulty = slopeDifficulty;
            slope.Status = status;            

            db.Entry(slope).State = EntityState.Modified;
            await db.SaveChangesAsync();

            return true;
        }
    }
}
