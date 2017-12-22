namespace SkiResorts.Data.Models
{
    using Common;
    using System.ComponentModel.DataAnnotations;

    public class Slope
    {
        public int Id { get; set; }

        [MinLength(DataConstants.SlopeNameMinLength)]
        [MaxLength(DataConstants.SlopeNameMaxLength)]
        public string Name { get; set; }

        [Range(DataConstants.SlopeMinLength, DataConstants.SlopeMaxLength)]
        public int Length { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public SlopeDifficulty Difficulty { get; set; }

        public Resort Resort { get; set; }

        public int ResortId { get; set; }
    }
}
