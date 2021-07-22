using GymManagerWebApp.Models;
using GymManagerWebApp.Services;
using GymManagerWebApp.Services.FileService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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

                else
                {
                    foreach (var error in result.Errors)
                    {
                        _logger.LogDebug($"Failed to register new user, details: {error.Description}");
                        ModelState.AddModelError("", error.Description);
                    }
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
            var currentUserEditViewModel = _userService.CreateEditProfileViewModel((Customer)currentCustomer);

            return View(currentUserEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(EditProfileViewModel model)
        {
            var result = await _userService.UpdateUser(model);

            if (result.Succeeded)
            {
                _logger.LogInformation($"User of id: {model.Id} | Profle edited by his own");
                return View("EditProfileConfirmation");
            }

            foreach (var error in result.Errors)
            {
                _logger.LogDebug($"User of id: {model.Id} | Failed to edit profile by his own | Details: {error.Description}");
                ModelState.AddModelError("", error.Description);
            }
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> RemoveProfilePicture(EditProfileViewModel model)
        {
            var currentCustomer = await _userService.GetUserByIdAsync(model.Id);

            currentCustomer.ProfilePicture = null;
            await _userManager.UpdateAsync(currentCustomer);

            return RedirectToAction(nameof(EditProfile));
        }
    }
}