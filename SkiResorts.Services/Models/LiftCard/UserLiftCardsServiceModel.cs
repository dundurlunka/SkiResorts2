namespace SkiResorts.Services.Models.LiftCard
{
    using AutoMapper;
    using SkiResorts.Common.Mapping;
    using SkiResorts.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class UserLiftCardsServiceModel : IMapFrom<UserLiftCard>, IHaveCustomMapping
    {
        public int LiftCardId { get; set; }

        public DateTime PurchaseDate { get; set; }

        public DateTime LiftCardDate { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; }

        public void ConfigureMapping(Profile profile)
        {
            profile
                .CreateMap<UserLiftCard, UserLiftCardsServiceModel>()
                .ForMember(u => u.Name, cfg => cfg.MapFrom(u => u.LiftCard.Name));
        }
    }
}
