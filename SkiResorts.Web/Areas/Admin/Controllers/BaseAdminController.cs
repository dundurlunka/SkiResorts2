namespace SkiResorts.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = WebConstants.AdministratorRole)]
    [Area(WebConstants.AdminArea)]
    public abstract class BaseAdminController : Controller
    {
    }
}