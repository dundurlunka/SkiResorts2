namespace SkiResorts.Services.Models.Lifts
{
    using Common;
    using Common.Mapping;
    using Data.Models;
    using System.ComponentModel.DataAnnotations;

    public class LiftFormServiceModel : IMapFrom<Lift>
    {
        [Required]
        [MinLength(DataConstants.LiftNameMinLength)]
        [MaxLength(DataConstants.LiftNameMaxLength)]
        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Seats { get; set; }

        [Display(Name="Vertical Drop")]
        public int VerticalDrop { get; set; }

        public int Length { get; set; }

        [Required]
        public Status Status { get; set; }
    }
}
