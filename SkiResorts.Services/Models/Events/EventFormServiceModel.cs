namespace SkiResorts.Services.Models.Events
{
    using Common;
    using SkiResorts.Common.Mapping;
    using Data.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class EventFormServiceModel : IMapFrom<Event>, IValidatableObject
    {
        [Required]
        [StringLength(DataConstants.EventNameMaxLength, MinimumLength = DataConstants.EventNameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(DataConstants.EventDescriptionMaxLength, MinimumLength = DataConstants.EventDescriptionMinLength)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name="Resort")]
        public int ResortId { get; set; }

        public string ManagerId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Date < DateTime.UtcNow)
            {
                yield return new ValidationResult("Event date must be in the future");
            }
        }
    }
}
