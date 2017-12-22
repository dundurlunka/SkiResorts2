namespace SkiResorts.Web.Areas.Resort.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SkiResorts.Web.Controllers;

    [Authorize(Roles = WebConstants.AdministratorRole + "," + WebConstants.ResortOwnerRole)]
    [Area(WebConstants.ResortArea)]
    public abstract class BaseResortController : Controller
    {
        private const string HomeControllerString = "Home";
        private const string IndexAction = nameof(HomeController.Index);

        public RedirectToActionResult RedirectToHome()
        {
            return RedirectToAction(IndexAction, HomeControllerString, new { area = "" });
        }
    }
}