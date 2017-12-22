namespace SkiResorts.Services.Models.Events
{
    using Common.Mapping;
    using Data.Models;
    using System;

    public class EventListingServiceModel : IMapFrom<Event>
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public int ResortId { get; set; }
    }
}
