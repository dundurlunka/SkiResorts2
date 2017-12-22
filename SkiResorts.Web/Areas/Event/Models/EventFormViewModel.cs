namespace SkiResorts.Web.Areas.Event.Models
{
    using Common.Mapping;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Services.Models.Events;
    using System.Collections.Generic;

    public class EventFormViewModel : EventFormServiceModel, IMapFrom<EventFormServiceModel>
    {
        public IEnumerable<SelectListItem> Resorts { get; set; }
    }
}
