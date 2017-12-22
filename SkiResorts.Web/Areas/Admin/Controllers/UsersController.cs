namespace SkiResorts.Web.Areas.Admin.Controllers
{
    using Data.Models;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using Models.Users;
    using Services;
    using System.Linq;
    using System.Threading.Tasks;

    public class UsersController : BaseAdminController
    {
        private readonly IAdminUserService adminUserService;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public UsersController(IAdminUserService adminUserService, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            this.adminUserService = adminUserService;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<IActionResult> All()
        {
            var users = await this
                .adminUserService
                .GetAllUsersAsync();

            var roles = await this
                .roleManager
                .Roles
                .Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Name
                })
                .ToListAsync();
            return View(new UserListingViewModel
            {
                Users = users,
                Roles = roles
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddToRole(AddToRoleModel model)
        {
            var roleExists = await this.roleManager.RoleExistsAsync(model.Role);
            var user = await this.userManager.FindByIdAsync(model.UserId);
            var userExists = user != null;

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(All));
            }

            if (!roleExists || !userExists)
            {
                return RedirectToAction(nameof(All));
            }

            var result = await userManager.AddToRoleAsync(user, model.Role);

            if (!result.Succeeded)
            {
                TempData.AddErrorMessage($"User {user.UserName} was NOT set to a role of {model.Role}");
                return RedirectToAction(nameof(All));
            }

            TempData.AddSuccessMessage($"User {user.UserName} was set to a role of {model.Role}");
            return RedirectToAction(nameof(All));

        }
    }
}