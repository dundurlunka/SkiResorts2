namespace SkiResorts.Services.Models.Slopes
{
    using Common.Mapping;
    using Data.Models;

    public class SlopeListingServiceModel : IMapFrom<Slope>
    {
        public int Id { get; set; }
       
        public string Name { get; set; }
        
        public int Length { get; set; }

        public Status Status { get; set; }

        public SlopeDifficulty Difficulty { get; set; }

        public int ResortId { get; set; }
    }
}
