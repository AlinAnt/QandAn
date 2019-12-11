using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QandAn.Models;
using static QandAn.Areas.Identity.Pages.Account.RegisterModel;

namespace QandAn.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AlinUser> _userManager;
        public HomeController(UserManager<AlinUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        { 
            var user = await _userManager.GetUserAsync(User);
            return View(user);
        }

        // public IActionResult Privacy()
        // {
        //     return View();
        // }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
