using System;
using System.Collections.Generic;
using System.Linq;
namespace SkiResorts.Web.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Services;
    using Data.Models;
    using Infrastructure.Extensions;
    using Models.LiftCards;

    [Authorize]
    public class LiftCardsController : Controller
    {
        private readonly ILiftCardService liftCardService;
        private readonly IResortService resortService;
        private readonly UserManager<User> userManager;

        public LiftCardsController(ILiftCardService liftCardService, IResortService resortService, UserManager<User> userManager)
        {
            this.liftCardService = liftCardService;
            this.resortService = resortService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Buy(int id)
        {
            if (!await this.resortService.ResortExistsAsync(id))
            {
                TempData.AddErrorMessage("Resort does not exist");
                return RedirectToAction(nameof(HomeController.Index), "Home", new { area = "" });
            }

            var liftCards = await this.liftCardService.GetLiftCardsForSelectAsync(id);

            if (liftCards.Count() == 0)
            {
                TempData.AddErrorMessage("Resort does not have lift cards");
                return RedirectToAction(nameof(HomeController.Index), "Home", new { area = "" });
            }

            return View(new LiftCardBuyViewModel
            {
                LiftCardDate = DateTime.UtcNow,
                LiftCards = liftCards.Select(lf => new SelectListItem
                {
                    Text = lf.Name,
                    Value = lf.Id.ToString()
                }).ToList()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Buy(LiftCardBuyViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                model.LiftCards = this.liftCardService.GetLiftCardsForSelectAsync(id).Result.Select(lf => new SelectListItem
                {
                    Text = lf.Name,
                    Value = lf.Id.ToString()
                }).ToList();
                return View(model);
            }
            if (!await this.liftCardService.LiftCardExistsAsync(model.LiftCardId))
            {
                TempData.AddErrorMessage("Lift card not found");
                return RedirectToAction(nameof(HomeController.Index), "Home", new { area = "" });
            }

            var userId = this.userManager.GetUserId(User);

            await this.liftCardService.BuyLiftCard(userId, model.LiftCardDate, model.DaysSelected * model.Price, model.LiftCardId);

            TempData.AddSuccessMessage("Lift card bought");
            return RedirectToAction(nameof(HomeController.Index), "Home", new { area = "" });
        }

        public async Task<IActionResult> GetLiftCardData(int id)
        {
            if (await this.liftCardService.LiftCardExistsAsync(id))
            {
                var liftCardData = await this.liftCardService.GetLiftCardBuyInfoAsync(id);

                return Json(liftCardData);
            }
            return BadRequest();
        }
    }
}