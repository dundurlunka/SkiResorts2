namespace SkiResorts.Services.Models.Resorts
{
    using Common.Mapping;
    using Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ResortShortModel : IMapFrom<Resort>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
