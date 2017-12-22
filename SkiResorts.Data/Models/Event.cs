namespace SkiResorts.Data.Models
{
    using Common;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Event
    {
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.EventNameMaxLength, MinimumLength = DataConstants.EventNameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(DataConstants.EventDescriptionMaxLength, MinimumLength = DataConstants.EventDescriptionMinLength)]
        public string Description { get; set; }
        
        public DateTime Date { get; set; }

        public Resort Resort { get; set; }

        public int ResortId { get; set; }

        public User Manager { get; set; }

        public string ManagerId { get; set; }
    }
}
