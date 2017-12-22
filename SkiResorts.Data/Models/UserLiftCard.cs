using AutoMapper;
using SkiResorts.Common;
using SkiResorts.Common.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SkiResorts.Data.Models
{
    public class UserLiftCard : IValidatableObject
    {
        public string UserId { get; set; }

        public User User { get; set; }

        public int LiftCardId { get; set; }

        public LiftCard LiftCard { get; set; }

        public DateTime PurchaseDate { get; set; }

        public DateTime LiftCardDate { get; set; }

        [Range(DataConstants.LiftCardPriceMin, DataConstants.LiftCardPriceMax)]
        public decimal Price { get; set; }

        public IEnumerable<ValidationResult> Validate(System.ComponentModel.DataAnnotations.ValidationContext validationContext)
        {
            if (this.LiftCardDate < DateTime.UtcNow)
            {
                yield return new ValidationResult("Lift card date must be in the future");
            }
        }
    }
}
