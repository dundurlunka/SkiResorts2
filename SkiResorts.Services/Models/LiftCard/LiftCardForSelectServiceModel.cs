namespace SkiResorts.Services.Models.LiftCard
{
    using SkiResorts.Common.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using SkiResorts.Data.Models;

    public class LiftCardForSelectServiceModel : IMapFrom<LiftCard>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
