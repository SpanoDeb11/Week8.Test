using AcademyG.Week8.Esercitazione.Core.Entities;
using AcademyG.Week8.Esercitazione.Core.Repositories;
using AcademyG.Week8.Esercitazione.MVC.Helper;
using AcademyG.Week8.Esercitazione.MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AcademyG.Week8.Esercitazione.MVC.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        private readonly IMainBusinessLayer _mainBL;

        public UserController(IMainBusinessLayer layer)
        {
            this._mainBL = layer;
        }

        public IActionResult Login(string returnURL)
        {
            return View(new UserLoginViewModel { ReturnURL = returnURL });
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel uvm)
        {
            if (uvm == null)
                return View("ExceptionsError", new ResultBL(false, "Invalid user"));

            var user = _mainBL.GetUserByEmail(uvm.Email);
            if (user != null && ModelState.IsValid)
            {
                if (user.Password.Equals(uvm.Password))
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.Role.ToString())
                    };

                    var authProperties = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
                        RedirectUri = uvm.ReturnURL
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties
                    );
                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError(nameof(uvm.Password), "Incorrect password");
                    return View(uvm);
                }
            }
            else
            {
                ModelState.AddModelError(nameof(uvm.Email), "Invalid email");
                return View(uvm);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        public IActionResult Register()
        {
            return View(new UserRegistrationViewModel());
        }

        [HttpPost]
        public IActionResult Register(UserRegistrationViewModel urvm)
        {
            if (!ModelState.IsValid)
                return View(urvm);

            var user = urvm.ToUser();

            var result = this._mainBL.CreateNewUser(user);
            if (result.Success)
                return Redirect("/");
            else
                return View("ExceptionError", result);
        }

        public IActionResult Forbidden()
        {
            return View();
        }
    }
}
