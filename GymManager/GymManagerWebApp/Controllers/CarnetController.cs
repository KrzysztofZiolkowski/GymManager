using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GymManagerWebApp.Models;
using GymManagerWebApp.Services;
using GymManagerWebApp.Services.CarnetService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GymManagerWebApp.Controllers
{
    public class CarnetController : Controller
    {
        private  ICarnetService _carnetService;
        private readonly ILogger<CarnetController> _logger;
        private readonly IUserService _userService;

        public CarnetController(ICarnetService carnetService, ILogger<CarnetController> logger, IUserService userService)
        {
            _carnetService = carnetService;
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult BuyCarnet()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> BuyCarnet(Carnet model)
        {
            const string CARNET_FIELD = "CarnetType";
            var carnetTypeNr = Int32.Parse(HttpContext.Request.Form[CARNET_FIELD]);
            var currentUserEmail = HttpContext.User.Identity.Name;
            var currentUser = _userService.GetUserByEmailAsync(currentUserEmail);
            var userId = currentUser.Id;

            _logger.LogInformation($"User with id:{userId} | Purchased ticket: ");
            return View("PurchaseConfirmation");
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> PurchasedCarnets(PurchasedCarnetsViewModel model)
        {
            var currentUserEmail = HttpContext.User.Identity.Name;

            return View("PurchasedCarnets", model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PurchasedCarnets(PurchasedCarnetsViewModel model, int carnetId) //Activates carnet
        {
            var userEmail = HttpContext.User.Identity.Name;
            var user = _userService.GetUserByEmailAsync(userEmail);


            
            _logger.LogInformation($"User of id: {user.Id} | activated carnet:");
            return View("ActivateCarnetConfirmation");
        }


        [Authorize(Roles ="Administrator")]
        [HttpGet]
        public async Task<IActionResult> AllPurchasedCarnets(PurchasedCarnetsViewModel model)
        {


            return View("PurchasedCarnets", model);
        }

    }
}
