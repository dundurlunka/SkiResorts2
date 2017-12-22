namespace SkiResorts.Services.Models.Slopes
{
    using Common.Mapping;
    using Common;
    using Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class SlopeFormServiceModel : IMapFrom<Slope>
    {
        [StringLength(DataConstants.SlopeNameMaxLength, MinimumLength = DataConstants.SlopeNameMinLength)]
        [Required]
        public string Name { get; set; }

        [Range(DataConstants.SlopeMinLength, DataConstants.SlopeMaxLength)]
        public int Length { get; set; }

        [Required]
        [Display(Name = "Slope difficulty")]
        public SlopeDifficulty Difficulty { get; set; }

        [Required]
        [Display(Name = "Status")]
        public Status Status { get; set; }
    }
}
