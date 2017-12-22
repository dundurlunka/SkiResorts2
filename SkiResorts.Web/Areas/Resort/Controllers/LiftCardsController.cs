namespace SkiResorts.Web.Areas.Resort.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Models.LiftCard;
    using Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SkiResorts.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Identity;
    using SkiResorts.Data.Models;

    public class LiftCardsController : BaseResortController
    {
        private readonly ILiftCardService liftCardService;
        private readonly IResortService resortService;
        private readonly UserManager<User> userManager;

        public LiftCardsController(ILiftCardService liftCardService, UserManager<User> userManager, IResortService resortService)
        {
            this.liftCardService = liftCardService;
            this.userManager = userManager;
            this.resortService = resortService;
        }

        public IActionResult Create()
        {
            var currentUserId = this.userManager.GetUserId(User);
            var currentUserResortId = this.resortService.GetResortIdOfUser(currentUserId);

            return View(new LiftCardFormServiceModel
            {
                ResortId = currentUserResortId
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(LiftCardFormServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await this.liftCardService.CreateAsync(model);

            TempData.AddSuccessMessage("Lift card created");
            return RedirectToHome();
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!await this.liftCardService.LiftCardExistsAsync(id))
            {
                TempData.AddErrorMessage("Lift card does not exist");
                return RedirectToHome();
            }

            if (!User.IsInRole(WebConstants.AdministratorRole))
            {
                if (!await this.liftCardService.IsLiftCardOfUser(id, User.Identity.Name))
                {
                    TempData.AddErrorMessage("You do not own this lift card");
                    return RedirectToHome();
                }
            }

            var liftCard = await this.liftCardService.GetLiftCardFormModel(id);

            return View(liftCard);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(LiftCardFormServiceModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!await this.liftCardService.LiftCardExistsAsync(id))
            {
                TempData.AddErrorMessage("Lift card does not exist");
                return RedirectToHome();
            }

            if (!User.IsInRole(WebConstants.AdministratorRole))
            {
                if (!await this.liftCardService.IsLiftCardOfUser(id, User.Identity.Name))
                {
                    TempData.AddErrorMessage("You do not own this lift card");
                    return RedirectToHome();
                }
            }

            await this.liftCardService.EditAsync(model, id);

            TempData.AddSuccessMessage("Lift card was edited");
            return RedirectToHome();
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!await this.liftCardService.LiftCardExistsAsync(id))
            {
                TempData.AddErrorMessage("Lift card does not exist");
                return RedirectToHome();
            }

            if (!User.IsInRole(WebConstants.AdministratorRole))
            {
                if (!await this.liftCardService.IsLiftCardOfUser(id, User.Identity.Name))
                {
                    TempData.AddErrorMessage("You do not own this lift card");
                    return RedirectToHome();
                }
            }

            await this.liftCardService.DeleteAsync(id);

            TempData.AddSuccessMessage("Lift card was deleted");
            return RedirectToHome();
        }
    }
}