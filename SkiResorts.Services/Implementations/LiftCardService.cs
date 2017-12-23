namespace SkiResorts.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models.LiftCard;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class LiftCardService : ILiftCardService
    {
        private readonly SkiResortsDbContext db;
        private readonly IPdfGenerator pdfGenerator;

        public LiftCardService(SkiResortsDbContext db, IPdfGenerator pdfGenerator)
        {
            this.db = db;
            this.pdfGenerator = pdfGenerator;
        }

        public async Task BuyLiftCard(string userId, DateTime liftCardDate, decimal price, int liftCardId)
        {
            var liftCard = await this.GetLiftCardEntityAsync(liftCardId);
            liftCard.Sales++;

            var userLiftCard = new UserLiftCard
            {
                LiftCardId = liftCardId,
                UserId = userId,
                LiftCardDate = liftCardDate,
                PurchaseDate = DateTime.UtcNow,
                Price = price
            };

            await db.AddAsync(userLiftCard);
            await db.SaveChangesAsync();
        }

        public async Task CreateAsync(LiftCardFormServiceModel model)
        {
            var liftCard = new LiftCard
            {
                Name = model.Name,
                Price = model.Price,
                MaxDaysToUse = model.MaxDaysToUse,
                NumberOfPeople = model.NumberOfPeople,
                ResortId = model.ResortId
            };

            await db.LiftCards.AddAsync(liftCard);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAllAsync(int resortId)
        {
            var liftCards = await GetAllLiftCards(resortId);

            foreach (var liftCard in liftCards)
            {
                for (int i = 0; i < liftCard.Users.Count(); i++)
                {
                    liftCard.Users.RemoveAt(i);
                    i--;
                }
            }
            await db.SaveChangesAsync();
        }

        public async Task<ICollection<LiftCard>> GetAllLiftCards(int resortId)
            => await this
                .db
                .LiftCards
                .Include(lf => lf.Users)
                .Where(lf => lf.ResortId == resortId)
                .ToListAsync();

        public async Task DeleteAsync(int id)
        {
            var liftCard = await this.GetLiftCardEntityAsync(id);

            for (int i = 0; i < liftCard.Users.Count(); i++)
            {
                liftCard.Users.RemoveAt(i);
                i--;
            }

            this.db.Remove(liftCard);
            await this.db.SaveChangesAsync();
        }

        public async Task EditAsync(LiftCardFormServiceModel model, int id)
        {
            var liftCard = await this.GetLiftCardEntityAsync(id);

            liftCard.Name = model.Name;
            liftCard.NumberOfPeople = model.NumberOfPeople;
            liftCard.Price = model.Price;
            liftCard.MaxDaysToUse = model.MaxDaysToUse;

            await this.db.SaveChangesAsync();
        }

        public async Task<LiftCardUserListingServiceModel> GetBoughtLiftCards(string userId)
            => await this
                .db
                .Users
                .Where(u => u.Id == userId)
                .Include(u => u.LiftCards)
                .ThenInclude(u => u.LiftCard)
                .ProjectTo<LiftCardUserListingServiceModel>()
                .FirstOrDefaultAsync();

        public async Task<LiftCardBuyServiceModel> GetLiftCardBuyInfoAsync(int id)
            => await this
                .db
                .LiftCards
                .Where(lf => lf.Id == id)
                .ProjectTo<LiftCardBuyServiceModel>()
                .FirstOrDefaultAsync();

        public async Task<LiftCard> GetLiftCardEntityAsync(int liftCardId)
            => await this
                .db
                .LiftCards
                .Include(lf => lf.Users)
                .FirstOrDefaultAsync(l => l.Id == liftCardId);

        public async Task<LiftCardFormServiceModel> GetLiftCardFormModel(int liftCardId)
            => await this
                .db
                .LiftCards
                .Where(l => l.Id == liftCardId)
                .ProjectTo<LiftCardFormServiceModel>()
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<LiftCardForSelectServiceModel>> GetLiftCardsForSelectAsync(int resortId)
            => await this
                .db
                .LiftCards
                .Where(lf => lf.ResortId == resortId)
                .ProjectTo<LiftCardForSelectServiceModel>()
                .ToListAsync();

        public async Task<bool> IsLiftCardOfUser(int liftCardId, string name)
        {
            var result = await this
                .db
                .LiftCards
                .Include(l => l.Resort)
                .ThenInclude(r => r.Owner)
                .AnyAsync(l => l.Id == liftCardId && l.Resort.Owner.UserName == name);

            return result;
        }

        public Task<bool> LiftCardExistsAsync(int liftCardId)
            => this
                .db
                .LiftCards
                .AnyAsync(l => l.Id == liftCardId);

        public async Task<byte[]> GetPdfLiftCard(int liftCardId, string userId, DateTime liftCardDate)
        {
            var userLiftCard = await this.db
                .FindAsync<UserLiftCard>(userId, liftCardId, liftCardDate);

            if (userLiftCard == null)
            {
                return null;
            }

            return this.pdfGenerator.GeneratePdfFromHtml(string.Format(
                ServiceConstants.PdfLiftCardFormat,
                userLiftCard.PurchaseDate,
                userLiftCard.LiftCardDate,
                userLiftCard.LiftCardId,
                userLiftCard.UserId,
                userLiftCard.Price));
        }
    }
}
