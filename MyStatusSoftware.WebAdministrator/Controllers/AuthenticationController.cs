using Microsoft.AspNetCore.Mvc;

namespace MyStatusSoftware.WebAdministrator.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
