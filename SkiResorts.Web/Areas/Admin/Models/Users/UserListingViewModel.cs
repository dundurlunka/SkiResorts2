namespace SkiResorts.Web.Areas.Admin.Models.Users
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Services.Models.Admin;
    using System.Collections.Generic;

    public class UserListingViewModel
    {
        public IEnumerable<UserListingServiceModel> Users { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}
