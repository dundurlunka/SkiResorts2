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
    }
}