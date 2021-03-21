﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GymManagerWebApp.Models;
using GymManagerWebApp.Services;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace GymManagerWebApp.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;
        private IUserValidation _userValidation;

        public UserController(IUserService userService, IUserValidation userValidation)
        {
            _userService = userService;
            _userValidation = userValidation;
        }

        #region Login
        [HttpGet]
        public IActionResult LogIn()
        {
            var login = new Login();
            return View(login);
        }
        [HttpPost]
        public async Task<IActionResult> PostLogIn(Login login)
        {
            await _userService.LoginUserAsync(login.Email, login.Password);
            return View();
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ForgotEmail()
        {
            return View();
        }



        #endregion
        #region Register
        [HttpGet]
        public IActionResult GetUser()
        {
            var user = new User();
            return View(user);
        }

        [HttpPost] 
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostUserAsync(User model)
        {
            model.Gender = HttpContext.Request.Form["Gender"].ToString();
            Guid id = Guid.NewGuid();
            DateTime createdAt =DateTime.UtcNow;
            string rights = "standard user";

            if (await _userValidation.IsValidAsync(model))
            {
                string hashPassword = await _userService.EncryptBySha256Hash(model.Password1);
                await _userService.RegisterUserAsync(model,hashPassword,id,createdAt,rights);
                return View("SignInSuccess",model);
            }

            return Redirect("GetUser");
        }
        #endregion
            
    }



}
