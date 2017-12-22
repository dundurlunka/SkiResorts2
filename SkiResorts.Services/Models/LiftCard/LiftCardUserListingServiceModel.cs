namespace SkiResorts.Services.Models.LiftCard
{
    using AutoMapper;
    using SkiResorts.Common.Mapping;
    using SkiResorts.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LiftCardUserListingServiceModel : IMapFrom<User>, IHaveCustomMapping
    {
        public ICollection<UserLiftCardsServiceModel> LiftCards { get; set; }

        public void ConfigureMapping(Profile profile)
        {
            profile
                .CreateMap<User, LiftCardUserListingServiceModel>()
                .ForMember(u => u.LiftCards, cfg => cfg.MapFrom(u => u.LiftCards));
        }
    }
}
