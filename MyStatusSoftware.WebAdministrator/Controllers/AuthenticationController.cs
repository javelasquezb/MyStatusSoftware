using Microsoft.AspNetCore.Mvc;
using MyStatusSoftware.WebAdministrator.Models.Authentication;

namespace MyStatusSoftware.WebAdministrator.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel viewModel)
        {
            return Json(new { msg = "Lo estamos logrando"});
        }
    }
}
