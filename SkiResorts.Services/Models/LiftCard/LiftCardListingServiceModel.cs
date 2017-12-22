namespace SkiResorts.Services.Models.LiftCard
{
    using Common.Mapping;
    using Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class LiftCardListingServiceModel : IMapFrom<LiftCard>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Sales { get; set; }

        [Display(Name = "Max days of usage")]
        public int MaxDaysToUse { get; set; }

        [Display(Name = "Number of people")]
        public int NumberOfPeople { get; set; }

        public int ResortId { get; set; }
    }
}
