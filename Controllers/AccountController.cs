using Microsoft.AspNetCore.Mvc;

namespace PanelProject.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}