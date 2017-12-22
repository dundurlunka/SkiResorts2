namespace SkiResorts.Data.Models
{
    using Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class LiftCard
    {
        public int Id { get; set; }

        [MinLength(DataConstants.LiftCardNameMinLength)]
        [MaxLength(DataConstants.LiftCardNameMaxLength)]
        public string Name { get; set; }

        [Range(DataConstants.LiftCardPriceMin, DataConstants.LiftCardPriceMax)]
        public decimal Price { get; set; }

        [Range(DataConstants.LiftCardMaxDaysToUseMin, DataConstants.LiftCardMaxDaysToUseMax)]
        public int MaxDaysToUse { get; set; }

        [Range(DataConstants.LiftCardNumberOfPeopleMin, DataConstants.LiftCardNumberOfPeopleMax)]
        public int NumberOfPeople { get; set; }

        public int Sales { get; set; }

        public IList<UserLiftCard> Users { get; set; } = new List<UserLiftCard>();

        public Resort Resort { get; set; }

        public int ResortId { get; set; }
    }
}
