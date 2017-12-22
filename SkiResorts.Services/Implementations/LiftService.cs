namespace SkiResorts.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using SkiResorts.Data;
    using SkiResorts.Services.Models.Lifts;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class LiftService : ILiftService
    {
        private readonly SkiResortsDbContext db;
        private readonly IResortService resortService;

        public LiftService(SkiResortsDbContext db, IResortService resortService)
        {
            this.db = db;
            this.resortService = resortService;
        }

        public async Task CreateAsync(string name, int capacity, int seats, int verticalDrop, int length, Status status, string userId)
        {
            var resortId = this.resortService.GetResortIdOfUser(userId);

            var lift = new Lift
            {
                Name = name,
                Capacity = capacity,
                Seats = seats,
                VerticalDrop = verticalDrop,
                Length = length,
                Status = status,
                ResortId = resortId
            };

            await db.AddAsync(lift);
            await db.SaveChangesAsync();
        }

        public async Task<bool> LiftExistsAsync(int id)
            => await db
                .Lifts
                .AnyAsync(l => l.Id == id);

        public async Task<bool> IsLiftOfUserAsync(int id, string username)
            => await db
                .Lifts
                .Include(l => l.Resort)
                .AnyAsync(l => l.Id == id && l.Resort.Owner.UserName == username);

        public async Task<LiftFormServiceModel> GetLiftFormModelAsync(int liftId)
            => await db
                .Lifts
                .Where(l => l.Id == liftId)
                .ProjectTo<LiftFormServiceModel>()
                .FirstOrDefaultAsync();

        public async Task Edit(string name, int capacity, int seats, int verticalDrop, Status status, int length, int liftId)
        {
            var lift = await this.GetLiftAsync(liftId);

            lift.Name = name;
            lift.Capacity = capacity;
            lift.Seats = seats;
            lift.VerticalDrop = verticalDrop;
            lift.Status = status;
            lift.Length = length;

            db.Entry(lift).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task<Lift> GetLiftAsync(int liftId)
            => await this
                .db
                .Lifts
                .Where(l => l.Id == liftId)
                .FirstOrDefaultAsync();

        public async Task DeleteAsync(int liftId)
        {
            var lift = await this.GetLiftAsync(liftId);

            if (lift == null)
            {
                return;
            }

            db.Remove(lift);
            await db.SaveChangesAsync();
        }
    }
}
