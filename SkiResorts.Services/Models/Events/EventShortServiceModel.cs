namespace SkiResorts.Services.Models.Events
{
    using Common.Mapping;
    using Data.Models;
    using System;

    public class EventShortServiceModel : IMapFrom<Event>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }
    }
}
