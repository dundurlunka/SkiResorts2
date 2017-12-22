namespace SkiResorts.Services.Models.Lifts
{
    using Common.Mapping;
    using Data.Models;

    public class LiftListingServiceModel : IMapFrom<Lift>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Seats { get; set; }

        public int VerticalDrop { get; set; }

        public int Length { get; set; }
        
        public Status Status { get; set; }

        public int ResortId { get; set; }
    }
}
