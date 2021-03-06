using GymManagerWebApp.Models;
using GymManagerWebApp.Services;
using GymManagerWebApp.Services.FileService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GymManagerWebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IFileService _fileService;
        private readonly UserManager<User> _userManager;

        public UserController(IUserService userService, UserManager<User> userManager, IFileService fileService)
        {
            _userService = userService;
            _userManager = userManager;
            _fileService = fileService;
        }

        #region Register
        [Route("SignIn")]
        [HttpGet]
        public IActionResult SignIn()
        {
            var user = new SignInUserViewModel();
            return View(user);
        }

        [Route("SignIn")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignInAsync(SignInUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Email = model.Email,
                    UserName = model.Email,
                    FirstName = char.ToUpper(model.FirstName[0]) + model.FirstName.Substring(1),
                    LastName = char.ToUpper(model.LastName[0]) + model.LastName.Substring(1),
                    PhoneNumber = model.PhoneNumber,
                    Gender = model.Gender,
                    CreatedAt = DateTime.UtcNow,
                    ProfilePicture = _fileService.UploadFile(model),
                };

                var result = await _userManager.CreateAsync(user, model.Password1);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user,"Klient");
                    return View("SignInConfirmation");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                ModelState.Clear();
                ModelState.AddModelError("", "Użytkownik o tej nazwie jest już zarejestrowany, spróbuj jeszcze raz!");
            }
            return View();
        }

        #endregion
        #region Login
        [Route("LogIn")]
        [HttpGet]
        public IActionResult LogIn()
        {
            var login = new Login();
            return View(login);
        }

        [Route("LogIn")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogInAsync(Login login, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.LoginAsync(login);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Nieprawidłowe dane logowania. Spróbój ponownie");
            }

            return View("LogIn", login);
        }

        [Route("Logout")]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _userService.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> AccountDetails()
        {
            string userEmail = User.Identity.Name;
            var user = await _userService.GetUserByEmailAsync(userEmail);
            return View("AccountDetails",user);
        }

        [HttpPost]
        public IActionResult AccountDetails(User model)
        {
            return RedirectToAction(nameof(EditProfile));
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var userEmail = User.Identity.Name;
            var user = await _userService.GetUserByEmailAsync(userEmail);

            var model = new EditProfileViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                PhoneNumber = user.PhoneNumber,
                ProfilePicturePath = user.ProfilePicture,
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> EditProfile(EditProfileViewModel model)
        {
            var userEmail = User.Identity.Name;
            var user = await _userService.GetUserByEmailAsync(userEmail);

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.PhoneNumber = model.PhoneNumber;
            user.Gender = model.Gender;

            if (model.ProfilePicture != null)
            {
                user.ProfilePicture = _fileService.UploadFile(model);
            }

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return View("EditProfileConfirmation");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> RemoveProfilePicture(EditProfileViewModel model)
        {
            var userEmail = User.Identity.Name;
            var user = await _userService.GetUserByEmailAsync(userEmail);

            user.ProfilePicture = null;
            await _userManager.UpdateAsync(user);

            return RedirectToAction(nameof(EditProfile));
        }
    }
}