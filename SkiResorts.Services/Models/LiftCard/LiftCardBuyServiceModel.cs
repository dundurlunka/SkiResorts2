namespace SkiResorts.Services.Models.LiftCard
{
    using SkiResorts.Common.Mapping;
    using SkiResorts.Data.Models;

    public class LiftCardBuyServiceModel : IMapFrom<LiftCard>
    {
        public decimal Price { get; set; }

        public int MaxDaysToUse { get; set; }

        public int NumberOfPeople { get; set; }
    }
}
