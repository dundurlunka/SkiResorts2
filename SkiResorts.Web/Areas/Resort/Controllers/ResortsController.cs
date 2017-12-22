namespace SkiResorts.Web.Areas.Resort.Controllers
{
    using Data.Models;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Services;
    using Services.Models.Resorts;
    using System.Threading.Tasks;

    public class ResortsController : BaseResortController
    {
        private readonly UserManager<User> userManager;
        private readonly IResortService resortService;
        private readonly IUserService userService;

        public ResortsController(UserManager<User> userManager, IResortService resortService, IUserService userService)
        {
            this.userManager = userManager;
            this.resortService = resortService;
            this.userService = userService;
        }

        public async Task<IActionResult> Create()
        {
            var ownerId = userManager
                .FindByNameAsync(this.User.Identity.Name)
                .Result
                .Id;

            if (await this.userService.UserHasResortAsync(ownerId))
            {
                TempData.AddWarningMessage("You already have a resort");
                return RedirectToHome();
            }

            return View(new ResortFormServiceModel
            {
                OwnerId = ownerId
            });
        }

        [HttpPost]
        public IActionResult Create(ResortFormServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            this.resortService.Create(model.Name, model.OwnerId);

            TempData.AddSuccessMessage($"Resort {model.Name} was added successfully");
            return RedirectToHome();
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!await this.resortService.ResortExistsAsync(id))
            {
                TempData.AddErrorMessage($"Resort with id {id} does not exist");
                return RedirectToHome();
            }

            if (!User.IsInRole(WebConstants.AdministratorRole))
            {
                if (!await resortService.IsResortOfUserAsync(id, User.Identity.Name))
                {
                    TempData.AddErrorMessage($"You are not the owner of the resort");
                    return RedirectToHome();
                }
            }

            var resort = await this.resortService.GetResortAsync(id);

            return View(resort);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ResortFormServiceModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!await this.resortService.ResortExistsAsync(id))
            {
                TempData.AddErrorMessage($"Resort with id {id} does not exist");
                return RedirectToHome();
            }

            if (!User.IsInRole(WebConstants.AdministratorRole))
            {
                if (!await resortService.IsResortOfUserAsync(id, User.Identity.Name))
                {
                    TempData.AddErrorMessage($"You are not the owner of the resort");
                    return RedirectToHome();
                }
            }

            await this.resortService.EditResortAsync(model.Name, id);

            TempData.AddSuccessMessage($"Resort's name was changed to {model.Name}");
            return RedirectToHome();
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!await this.resortService.ResortExistsAsync(id))
            {
                TempData.AddErrorMessage($"Resort does not exist");
                return RedirectToHome();
            }

            if (!User.IsInRole(WebConstants.AdministratorRole))
            {
                if (!await resortService.IsResortOfUserAsync(id, User.Identity.Name))
                {
                    TempData.AddErrorMessage($"You are not the owner of the resort");
                    return RedirectToHome();
                }
            }

            await this.resortService.DeleteResortAsync(id);

            TempData.AddSuccessMessage($"Resort was deleted");
            return RedirectToHome();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            if (!await this.resortService.ResortExistsAsync(id))
            {
                TempData.AddErrorMessage($"Resort with it {id} does not exist");
                return RedirectToHome();
            }

            var resort = await this.resortService.GetResortWithFacilities(id);

            return View(resort);
        }
    }
}