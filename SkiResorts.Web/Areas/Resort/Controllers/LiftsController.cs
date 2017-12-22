namespace SkiResorts.Web.Areas.Resort.Controllers
{
    using Data.Models;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Services;
    using Services.Models.Lifts;
    using System.Threading.Tasks;

    public class LiftsController : BaseResortController
    {
        private readonly ILiftService liftService;
        private readonly UserManager<User> userManager;

        public LiftsController(ILiftService liftService, UserManager<User> userManager)
        {
            this.liftService = liftService;
            this.userManager = userManager;
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(LiftFormServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var userId = userManager.FindByNameAsync(this.User.Identity.Name).Result.Id;

            await this.liftService.CreateAsync(model.Name, model.Capacity, model.Seats, model.VerticalDrop, model.Length, model.Status, userId);

            TempData.AddSuccessMessage($"Lift {model.Name} was sucessfully created");
            return RedirectToHome();
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!await this.liftService.LiftExistsAsync(id))
            {
                TempData.AddErrorMessage($"Lift does not exist");
                return RedirectToHome();
            }
            if (!User.IsInRole(WebConstants.AdministratorRole))
            {
                if (!await this.liftService.IsLiftOfUserAsync(id, User.Identity.Name))
                {
                    TempData.AddErrorMessage($"You do not own this lift");
                    return RedirectToHome();
                }
            }

            var lift = await this.liftService.GetLiftFormModelAsync(id);

            return View(lift);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(LiftFormServiceModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!await this.liftService.LiftExistsAsync(id))
            {
                TempData.AddErrorMessage($"Lift does not exist");
                return RedirectToHome();
            }
            if (!User.IsInRole(WebConstants.AdministratorRole))
            {
                if (!await this.liftService.IsLiftOfUserAsync(id, User.Identity.Name))
                {
                    TempData.AddErrorMessage($"You do not own this lift");
                    return RedirectToHome();
                }
            }

            await this.liftService.Edit(model.Name, model.Capacity, model.Seats, model.VerticalDrop, model.Status, model.Length, id);

            TempData.AddSuccessMessage($"Lift was edited");
            return RedirectToHome();
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!await this.liftService.LiftExistsAsync(id))
            {
                TempData.AddErrorMessage($"Lift does not exist");
                return RedirectToHome();
            }

            if (!User.IsInRole(WebConstants.AdministratorRole))
            {
                if (!await this.liftService.IsLiftOfUserAsync(id, User.Identity.Name))
                {
                    TempData.AddErrorMessage($"You do not own this lift");
                    return RedirectToHome();
                }
            }

            await this.liftService.DeleteAsync(id);
            return RedirectToHome();
        }
    }
}
