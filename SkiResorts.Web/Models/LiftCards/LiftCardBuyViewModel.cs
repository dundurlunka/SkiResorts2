namespace SkiResorts.Web.Models.LiftCards
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class LiftCardBuyViewModel
    {
        public ICollection<SelectListItem> LiftCards { get; set; }

        [Display(Name = "Lift Card")]
        public int LiftCardId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Card date")]
        public DateTime LiftCardDate { get; set; }

        public int DaysSelected { get; set; }

        public decimal Price { get; set; }
    }
}
