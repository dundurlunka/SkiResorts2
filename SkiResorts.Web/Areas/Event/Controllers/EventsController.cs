namespace SkiResorts.Web.Areas.Event.Controllers
{
    using Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Models;
    using Services;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Web.Controllers;

    [Authorize(Roles = WebConstants.EventManagerRole)]
    [Area(WebConstants.EventArea)]
    public class EventsController : Controller
    {
        private const string HomeControllerString = "Home";
        private const string IndexAction = nameof(HomeController.Index);

        private readonly IResortService resortService;
        private readonly IEventService eventService;
        private readonly UserManager<User> userManager;

        public EventsController(IResortService resortService, IEventService eventService, UserManager<User> userManager)
        {
            this.resortService = resortService;
            this.userManager = userManager;
            this.eventService = eventService;
        }

        public IActionResult Create()
        {
            var curentUserId = this.userManager.GetUserId(User);
            var resorts = this.resortService.GetResortsForSelect().Result.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id.ToString()
            });

            return View(new EventFormViewModel
            {
                Date = DateTime.UtcNow,
                ManagerId = curentUserId,
                Resorts = resorts
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(EventFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Resorts = this.resortService
                    .GetResortsForSelect()
                    .Result
                    .Select(r => new SelectListItem
                    {
                        Text = r.Name,
                        Value = r.Id.ToString()
                    });
                return View(model);
            }

            await this.eventService.Create(model.Name, model.Description, model.Date, model.ManagerId, model.ResortId);

            return RedirectToHome();
        }

        public RedirectToActionResult RedirectToHome()
        {
            return RedirectToAction(IndexAction, HomeControllerString, new { area = "" });
        }
    }
}