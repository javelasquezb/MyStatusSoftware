using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MyStatusSoftware.Data.Entities;
using MyStatusSoftware.Logics.Account;
using MyStatusSoftware.WebAdministrator.Models.Account;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyStatusSoftware.WebAdministrator.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountManager _authenticationManager;

        public AccountController(IAccountManager authenticationManager)
        {
            _authenticationManager = authenticationManager;
        }
        public IActionResult Login()
        {
            if (!User.Identity.IsAuthenticated)
                return View();
            else
                return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            try
            {
                var response = await _authenticationManager.Login(new User { Email = viewModel.Email,Password = viewModel.Password });
                if (response.Success)
                {
                    var user = JsonConvert.DeserializeObject<User>(response.Result.ToString());
                    await SignInAsync(user,viewModel.IsRemember);
                }
                return Json(new { success = response.Success,msg = response.Msg });
            }
            catch (Exception ex)
            {
                return Json(new { msg = ex.Message });
            }
        }

        public async Task<IActionResult> Logout()
        {
            await SignOutAsync();
            return RedirectToAction("Login");
        }

        #region Methods Private

        private async Task SignInAsync(User user,bool isPersistent)
        {
            var claims = new List<Claim>
             {
                 new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                 new Claim(ClaimTypes.Name,user.UserName),
                 new Claim(ClaimTypes.Email, user.Email),
                 new Claim(ClaimTypes.Role, user.UserType.ToString()),
                 new Claim(ClaimTypes.GivenName,user.FirstName),
                 new Claim(ClaimTypes.Surname,user.LastName),
             };

            var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                new AuthenticationProperties
                {
                    IsPersistent = isPersistent
                });
        }

        private async Task SignOutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
        #endregion
    }
}
