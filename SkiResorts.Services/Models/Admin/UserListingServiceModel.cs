namespace SkiResorts.Services.Models.Admin
{
    using AutoMapper;
    using Common.Mapping;
    using Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UserListingServiceModel : IMapFrom<User>, IHaveCustomMapping
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string ResortName { get; set; }

        public bool HasResort { get; set; }

        public int ResortId { get; set; }

        public IEnumerable<UserLiftCard> LiftCards { get; set; } = new List<UserLiftCard>();

        public void ConfigureMapping(Profile profile)
        {
            profile
                .CreateMap<User, UserListingServiceModel>()
                .ForMember(u => u.HasResort, cfg => cfg.MapFrom(p => p.Resort != null))
                .ForMember(u => u.ResortId, cfg => cfg.MapFrom(p => (p.Resort == null) ? 0 : p.Resort.Id))
                .ForMember(u => u.ResortName, cfg => cfg.MapFrom(u => (u.Resort == null) ? "No resort" : u.Resort.Name));
        }
    }
}
