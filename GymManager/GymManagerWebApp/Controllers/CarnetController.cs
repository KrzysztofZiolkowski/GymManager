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
        public async Task<IActionResult> BuyCarnet()
        {
            var CarnetsOfferViewModel = await _carnetService.GetCarnetOfferAsync();
            return View(CarnetsOfferViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> BuyCarnet(int carnetId)
        {
            var currentCustomerId = await _userService.GetUserIdByEmailAsync(User.Identity.Name);
            await _carnetService.BuyCarnetAsync(carnetId, currentCustomerId); ;

            return View("PurchaseConfirmation");
        }

        [HttpGet]
        public async Task<IActionResult> PurchasedCarnets()
        {
            var currentCustomerId = await _userService.GetUserIdByEmailAsync(User.Identity.Name);
            var purchasedCarnetsViewModel =  await _carnetService.GetPurchasedCarnetsAsync(currentCustomerId);

            return View(purchasedCarnetsViewModel);
        }

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
