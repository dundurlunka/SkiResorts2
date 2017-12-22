namespace SkiResorts.Services.Models.LiftCard
{
    using Common;
    using SkiResorts.Common.Mapping;
    using SkiResorts.Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class LiftCardFormServiceModel : IMapFrom<LiftCard>
    {
        [MinLength(DataConstants.LiftCardNameMinLength)]
        [MaxLength(DataConstants.LiftCardNameMaxLength)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [Display(Name="Max days of usage")]
        public int MaxDaysToUse { get; set; }

        [Display(Name="Number of people")]
        public int NumberOfPeople { get; set; }

        public int Sales { get; set; }

        public int ResortId { get; set; }
    }
}
