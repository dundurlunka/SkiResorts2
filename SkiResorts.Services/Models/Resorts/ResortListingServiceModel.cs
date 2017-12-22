namespace SkiResorts.Services.Models.Resorts
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;
    using Models.Events;
    using System;
    using System.Linq;

    public class ResortListingServiceModel : IMapFrom<Resort>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SlopesCount { get; set; }

        public int LiftsCount { get; set; }

        public EventShortServiceModel LatestEvent { get; set; }

        public string OwnerName { get; set; }

        public void ConfigureMapping(Profile profile)
        {
            profile
                .CreateMap<Resort, ResortListingServiceModel>()
                .ForMember(r => r.SlopesCount, cfg => cfg.MapFrom(r => r.Slopes.Count()))
                .ForMember(r => r.LiftsCount, cfg => cfg.MapFrom(r => r.Lifts.Count()))
                .ForMember(r => r.OwnerName, cfg => cfg.MapFrom(r => r.Owner.UserName))
                .ForMember(r => r.LatestEvent,
                    cfg => cfg
                        .MapFrom(r => r
                            .Events
                            .Where(e => e.Date > DateTime.UtcNow)
                            .OrderBy(e => e.Date)
                            .FirstOrDefault()));
        }
    }
}
