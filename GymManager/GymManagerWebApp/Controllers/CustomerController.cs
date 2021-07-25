using GymManagerWebApp.Models;
using GymManagerWebApp.Services;
using GymManagerWebApp.Services.FileService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagerWebApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IUserService _userService;
        private readonly IFileService _fileService;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<CustomerController> _logger;        

        public CustomerController(IUserService userService, UserManager<User> userManager, IFileService fileService, ILogger<CustomerController> logger)
        {
            _userService = userService;
            _userManager = userManager;
            _fileService = fileService;
            _logger = logger;
        }

        #region Register
        [Route("Register")]
        [HttpGet]
        public IActionResult Register()
        {
            var customerViewModel = new RegisterCustomerViewModel();
            return View(customerViewModel);
        }

        [Route("Register")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterCustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var customer = _userService.CreateCustomerViewModel(model);
                var result = await _userManager.CreateAsync(customer, model.Password1);

                if (result.Succeeded)
                {
                    string roleName = dbMock.ContextMock.GetCustomerRoleName();
                    await _userManager.AddToRoleAsync(customer, roleName);

                    _logger.LogInformation($"Customer register succeed, id: {customer.Id} ");
                    return View("RegisterConfirmation");
                }

                foreach (var error in result.Errors)
                {
                    _logger.LogDebug($"Failed to register new user, details: {error.Description}");
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }

        #endregion
        #region Login
        [Route("LogIn")]
        [HttpGet]
        public IActionResult LogIn()
        {
            var loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }

        [Route("LogIn")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.LoginAsync(model);
                var customer = await _userService.GetUserByEmailAsync(model.Email);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }

                    _logger.LogInformation($"User with id: {customer.Id} logged in");
                    return RedirectToAction("Index", "Home");
                }

                _logger.LogDebug($"Failed login attempt. User id: {customer.Id}");
                ModelState.AddModelError("", "Nieprawidłowe dane logowania. Spróbój ponownie");
            }

            return View("LogIn", model);
        }

        [Route("Logout")]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _userService.LogoutAsync();

            var customer = await _userManager.GetUserAsync(HttpContext.User);
            var customerId = customer.Id;

            _logger.LogInformation($"User with id: {customerId} logged out");
            return RedirectToAction("Index", "Home");
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> AccountDetails()
        {
            var currentCustomerEmail = User.Identity.Name;
            var currentCustomer = await _userService.GetUserByEmailAsync(currentCustomerEmail);

            return View("AccountDetails", currentCustomer);
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var currentCustomerEmail = User.Identity.Name;
            var currentCustomer = await _userService.GetUserByEmailAsync(currentCustomerEmail);
            var currentCustomerEditProfileViewModel = _userService.CreateEditProfileViewModel((Customer)currentCustomer);

            return View(currentCustomerEditProfileViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(EditProfileViewModel model)
        {
            var currentCustomerEmail = User.Identity.Name;
            var currentCustomer = await _userService.GetUserByEmailAsync(currentCustomerEmail);

            if (ModelState.IsValid)
            {
                var result = await _userService.UpdateCustomer(model, currentCustomer.Id);

                if (result.Succeeded)
                {
                    _logger.LogInformation($"User of id: {model.Id} | Profle edit succeeded");
                    return View("EditProfileConfirmation");
                }

                foreach (var error in result.Errors)
                {
                    _logger.LogDebug($"User of id: {model.Id} | Failed to edit profile| Details: {error.Description}");
                    ModelState.AddModelError("", error.Description);
                }
            }

            IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
            _logger.LogDebug($"User of id: {model.Id}| Failed to edit profile- wrong attributes | {allErrors}");

            var oldCustomerEditProfileViewModel = _userService.CreateEditProfileViewModel((Customer)currentCustomer);

            return View(oldCustomerEditProfileViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveProfilePicture(EditProfileViewModel model)
        {
            var currentCustomerEmail = User.Identity.Name;
            var currentCustomer = await _userService.GetUserByEmailAsync(currentCustomerEmail);

            currentCustomer.ProfilePicture = null;
            await _userManager.UpdateAsync(currentCustomer);

            return RedirectToAction(nameof(EditProfile));
        }
    }
}