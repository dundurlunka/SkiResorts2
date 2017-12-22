namespace SkiResorts.Web.Areas.Resort.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Services;
    using SkiResorts.Data.Models;
    using SkiResorts.Services.Models.Slopes;
    using SkiResorts.Web.Controllers;
    using SkiResorts.Web.Infrastructure.Extensions;
    using System.Linq;
    using System.Threading.Tasks;

    public class SlopesController : BaseResortController
    {
        private readonly ISlopeService slopeService;
        private readonly UserManager<User> userManager;

        public SlopesController(ISlopeService slopeService, UserManager<User> userManager)
        {
            this.slopeService = slopeService;
            this.userManager = userManager;
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(SlopeFormServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await userManager.FindByNameAsync(this.User.Identity.Name);
            var userId = user.Id;

            await this.slopeService.CreateAsync(model.Name, model.Length, model.Difficulty, model.Status, userId);

            TempData.AddSuccessMessage($"Slope {model.Name} was sucessfully created");
            return RedirectToHome();
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!await this.slopeService.SlopeExistsAsync(id))
            {
                TempData.AddErrorMessage($"Slope does not exist");
                return RedirectToHome();
            }

            if (!User.IsInRole(WebConstants.AdministratorRole))
            {
                if (!await this.slopeService.IsSlopeOfUserAsync(id, User.Identity.Name))
                {
                    TempData.AddErrorMessage($"You are not the owner of the resort");
                    return RedirectToHome();
                }
            }

            var slope = await this.slopeService.GetSlopeFormModelAsync(id);

            return View(slope);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SlopeFormServiceModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!await this.slopeService.SlopeExistsAsync(id))
            {
                TempData.AddErrorMessage($"Slope does not exist");
                return RedirectToHome();
            }

            if (!User.IsInRole(WebConstants.AdministratorRole))
            {
                if (!await this.slopeService.IsSlopeOfUserAsync(id, User.Identity.Name))
                {
                    TempData.AddErrorMessage("You are not the owner of the slope");
                    return RedirectToHome();
                }
            }

            var result = await this.slopeService.EditAsync(model.Name, model.Length, model.Difficulty, model.Status, id);
            if (!result)
            {
                TempData.AddErrorMessage($"Slope {model.Name} was not edited");
                return RedirectToHome();
            }

            TempData.AddSuccessMessage($"Slope was edited");
            return RedirectToHome();
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!await this.slopeService.SlopeExistsAsync(id))
            {
                TempData.AddErrorMessage($"Slope does not exist");
                return RedirectToHome();
            }

            if (!User.IsInRole(WebConstants.AdministratorRole))
            {
                if (!await this.slopeService.IsSlopeOfUserAsync(id, User.Identity.Name))
                {
                    TempData.AddErrorMessage($"You are not the owner of the slope");
                    return RedirectToHome();
                }
            }

            await this.slopeService.DeleteSlopeAsync(id);

            TempData.AddSuccessMessage($"Resort was deleted");
            return RedirectToHome();
        }
    }
}
