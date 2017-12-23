namespace SkiResorts.Services.Models.LiftCard
{
    using SkiResorts.Common;
    using SkiResorts.Common.Mapping;
    using SkiResorts.Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class LiftCardBuyServiceModel : IMapFrom<LiftCard>
    {
        [Range(DataConstants.LiftCardPriceMin, DataConstants.LiftCardPriceMax)]
        public decimal Price { get; set; }

        [Range(DataConstants.LiftCardMaxDaysToUseMin, DataConstants.LiftCardMaxDaysToUseMax)]
        public int MaxDaysToUse { get; set; }

        [Range(DataConstants.LiftCardNumberOfPeopleMin, DataConstants.LiftCardNumberOfPeopleMax)]
        public int NumberOfPeople { get; set; }
    }
}
