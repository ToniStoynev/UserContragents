using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserContragents.Domain;
using UserContragents.Models;
using UserContragents.Services.Contracts;

namespace UserContragents.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUsers> manager;
        private readonly IUserService userService;
        public HomeController(UserManager<AppUsers> manager, IUserService userService)
        {
            this.manager = manager;
            this.userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Profile()
        {
            var userId = manager.GetUserId(this.User);

            var viewModel = this.userService.GetUserById(userId);

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
