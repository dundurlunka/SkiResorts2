namespace SkiResorts.Data.Models
{
    using Common;
    using System.ComponentModel.DataAnnotations;

    public class Lift
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.LiftNameMinLength)]
        [MaxLength(DataConstants.LiftNameMaxLength)]
        public string Name { get; set; }

        [Range(DataConstants.LiftCapacityMin, DataConstants.LiftCapacityMax)]
        public int Capacity { get; set; }

        [Range(DataConstants.LiftSeatsMin, DataConstants.LiftSeatsMax)]
        public int Seats { get; set; }

        [Range(DataConstants.LiftVerticalDropMin, DataConstants.LiftVerticalDropMax)]
        public int VerticalDrop { get; set; }

        [Range(DataConstants.LiftLengthMin, DataConstants.LiftLengthMax)]
        public int Length { get; set; }

        [Required]
        public Status Status { get; set; }

        public Resort Resort { get; set; }

        public int ResortId { get; set; }
    }
}
