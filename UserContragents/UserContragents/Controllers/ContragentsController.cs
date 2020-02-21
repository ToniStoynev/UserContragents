using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserContragents.Models;
using UserContragents.Services.Contracts;

namespace UserContragents.Controllers
{
    public class ContragentsController : Controller
    {
        private readonly IContragentService contragentService;
        public ContragentsController(IContragentService contragentService)
        {
            this.contragentService = contragentService;
        }

        [Authorize]
        public IActionResult AddContragent()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddContragent(AddContragentBindingModel model)
        {

            if (!ModelState.IsValid)
            {
                return this.Redirect("/Contragents/AddContragent");
            }

            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            model.UserId = userId;

            this.contragentService.AddContragent(model);

            return this.Redirect("/Contragents/All");
        }

        [Authorize]
        public IActionResult All()
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var viewModel = this.contragentService.GetAll(userId).ToList();

            return this.View(viewModel);
        }

        public IActionResult Details(string id)
        {
            var viewModel = this.contragentService.GetContragentById(id);

            return this.View(viewModel);
        }
    }
}