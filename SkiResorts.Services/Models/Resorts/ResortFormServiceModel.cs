namespace SkiResorts.Services.Models.Resorts
{
    using Common;
    using Common.Mapping;
    using Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class ResortFormServiceModel : IMapFrom<Resort>
    {
        [Required]
        [StringLength(DataConstants.ResortNameMaxLength, MinimumLength = DataConstants.ResortNameMinLength)]
        public string Name { get; set; }

        [Required]
        public string OwnerId { get; set; }
    }
}
