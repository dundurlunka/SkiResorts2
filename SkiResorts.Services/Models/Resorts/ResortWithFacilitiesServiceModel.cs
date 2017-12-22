namespace SkiResorts.Services.Models.Resorts
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;
    using Events;
    using Lifts;
    using LiftCard;
    using Slopes;
    using System.Collections.Generic;

    public class ResortWithFacilitiesServiceModel : IMapFrom<Resort>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string OwnerName { get; set; }

        public ICollection<LiftListingServiceModel> Lifts { get; set; }

        public ICollection<SlopeListingServiceModel> Slopes { get; set; }

        public ICollection<EventListingServiceModel> Events { get; set; }

        public ICollection<LiftCardListingServiceModel> LiftCards { get; set; }

        public void ConfigureMapping(Profile profile)
        {
            profile
                .CreateMap<Resort, ResortWithFacilitiesServiceModel>()
                .ForMember(r => r.OwnerName, cfg => cfg.MapFrom(r => r.Owner.UserName));
        }
    }
}
