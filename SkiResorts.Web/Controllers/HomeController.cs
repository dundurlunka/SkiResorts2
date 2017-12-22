namespace SkiResorts.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using System.Diagnostics;
    using Services;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using SkiResorts.Data.Models;
    using Microsoft.Extensions.Caching.Memory;
    using SkiResorts.Services.Models.Resorts;
    using System.Collections.Generic;
    using System;

    public class HomeController : Controller
    {
        private readonly IResortService resortService;
        private readonly UserManager<User> userManager;
        private readonly IMemoryCache cache;
        
        public HomeController(IResortService resortService, UserManager<User> userManager, IMemoryCache cache)
        {
            this.resortService = resortService;
            this.userManager = userManager;
            this.cache = cache;
        }

        public async Task<IActionResult> Index()
        {
            const string cacheResortsKey = "Cache_All_Resorts";

            var resorts = this.cache.Get<IEnumerable<ResortListingServiceModel>>(cacheResortsKey);
            if (resorts == null)
            {
                resorts = await resortService.All();
                this.cache.Set(cacheResortsKey, resorts, DateTimeOffset.UtcNow.AddDays(1));
            }
            
            return View(resorts);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
