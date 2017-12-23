namespace SkiResorts.Services
{
    using Models.LiftCard;
    using SkiResorts.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ILiftCardService
    {
        Task CreateAsync(LiftCardFormServiceModel model);

        Task<LiftCardFormServiceModel> GetLiftCardFormModel(int liftCardId);

        Task<bool> LiftCardExistsAsync(int liftCardId);

        Task<bool> IsLiftCardOfUser(int liftCardId, string name);

        Task EditAsync(LiftCardFormServiceModel model, int id);

        Task<LiftCard> GetLiftCardEntityAsync(int liftCardId);

        Task DeleteAsync(int id);

        Task<IEnumerable<LiftCardForSelectServiceModel>> GetLiftCardsForSelectAsync(int resortId);

        Task<LiftCardBuyServiceModel> GetLiftCardBuyInfoAsync(int id);

        Task BuyLiftCard(string userId, DateTime liftCardDate, decimal price, int liftCardId);

        Task<LiftCardUserListingServiceModel> GetBoughtLiftCards(string userId);

        Task DeleteAllAsync(int resortId);

        Task<byte[]> GetPdfLiftCard(int id, string userId, DateTime liftCardDate);
    }
}
