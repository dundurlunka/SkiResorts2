namespace SkiResorts.Data.Models
{
    using Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Resort
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.ResortNameMinLength)]
        [MaxLength(DataConstants.ResortNameMaxLength)]
        public string Name { get; set; }

        public User Owner { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public ICollection<Slope> Slopes { get; set; } = new List<Slope>();

        public ICollection<Lift> Lifts { get; set; } = new List<Lift>();

        public ICollection<LiftCard> LiftCards { get; set; } = new List<LiftCard>();

        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
