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
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IFileService _fileService;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<UserController> _logger;        

        public UserController(IUserService userService, UserManager<User> userManager, IFileService fileService, ILogger<UserController> logger)
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
        public async Task<IActionResult> Register(RegisterCustomerViewModel newCustomer)
        {
            if (ModelState.IsValid)
            {
                var customer = _userService.CreateCustomerViewModel(newCustomer);
                var result = await _userManager.CreateAsync(customer, newCustomer.Password1);
                string roleName = "Klient";

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(customer, roleName);
                    _logger.LogInformation($"Customer register succeed, id: {customer.Id} ");
                    return View("SignInConfirmation");
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
                var user = await _userService.GetUserByEmailAsync(model.Email);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }

                    _logger.LogInformation($"User with id: {user.Id} logged in");
                    return RedirectToAction("Index", "Home");
                }

                _logger.LogDebug($"Failed login attempt. User id: {user.Id}");
                ModelState.AddModelError("", "Nieprawidłowe dane logowania. Spróbój ponownie");
            }

            return View("LogIn", model);
        }

        [Route("Logout")]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _userService.LogoutAsync();

            var user = await _userManager.GetUserAsync(HttpContext.User);
            var userId = user.Id;

            _logger.LogInformation($"User with id: {userId} logged out");
            return RedirectToAction("Index", "Home");
        }
        #endregion

        [HttpGet]
        public IActionResult AccountDetails()
        {
            return View("AccountDetails", User.Identity);
        }

        [HttpGet]
        public IActionResult EditProfile()
        {
            var currentUser = (Customer)User.Identity;
            var currentUserEditViewModel = _userService.CreateEditProfileViewModel(currentUser);

            return View(currentUserEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(EditProfileViewModel newUserData)
        {
            var result = await _userService.UpdateUser(newUserData);

            if (result.Succeeded)
            {
                _logger.LogInformation($"User of id: {newUserData.Id} | Profle edited by his own");
                return View("EditProfileConfirmation");
            }

            foreach (var error in result.Errors)
            {
                _logger.LogDebug($"User of id: {newUserData.Id} | Failed to edit profile by his own | Details: {error.Description}");
                ModelState.AddModelError("", error.Description);
            }
            return View(newUserData);

        }

        [HttpPost]
        public async Task<IActionResult> RemoveProfilePicture(EditProfileViewModel currentUser)
        {
            var user = await _userService.GetUserByIdAsync(currentUser.Id);

            user.ProfilePicture = null;
            await _userManager.UpdateAsync(user);

            return RedirectToAction(nameof(EditProfile));
        }
    }
}