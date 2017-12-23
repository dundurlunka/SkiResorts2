namespace SkiResorts.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using SkiResorts.Data.Models;
    using SkiResorts.Services;
    using SkiResorts.Web.Infrastructure.Extensions;

    [Authorize]
    public class UsersController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly ILiftCardService liftCardService;

        public UsersController(UserManager<User> userManager, ILiftCardService liftCardService)
        {
            this.userManager = userManager;
            this.liftCardService = liftCardService;
        }

        public async Task<IActionResult> MyLiftCards()
        {
            var userId = this.userManager.GetUserId(User);

            var liftCards = await this.liftCardService.GetBoughtLiftCards(userId);

            return View(liftCards);
        }

        public async Task<IActionResult> DownloadLiftCard(int id, DateTime liftCardDate)
        {
            var userId = this.userManager.GetUserId(User);

            var liftCardContent = await this.liftCardService.GetPdfLiftCard(id, userId, liftCardDate);

            if (liftCardContent == null)
            {
                TempData.AddWarningMessage("A problem downloading lift card occured");
                return RedirectToAction(nameof(MyLiftCards));
            }

            return File(liftCardContent, "application/pdf", "Lift-card.pdf");
        }
    }
}