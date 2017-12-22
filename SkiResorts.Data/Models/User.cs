namespace SkiResorts.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        public IEnumerable<UserLiftCard> LiftCards { get; set; } = new List<UserLiftCard>();

        public IEnumerable<Event> Events { get; set; } = new List<Event>();

        public Resort Resort { get; set; }
    }
}
