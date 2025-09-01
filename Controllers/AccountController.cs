using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PanelProject.Models;
using PanelProject.ViewModels;

namespace PanelProject.Controllers
{


    public class AccountController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        private readonly SignInManager<AppUser> _signInManager;


        public AccountController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;

        }
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, true);

                    if (result.Succeeded)
                    {
                        await _userManager.ResetAccessFailedCountAsync(user);
                        await _userManager.SetLockoutEndDateAsync(user, null);

                        return RedirectToAction("Index");

                    }
                    else if (result.IsLockedOut)
                    {
                        var lockoutDate = await _userManager.GetLockoutEndDateAsync(user);
                        var timeLeft = lockoutDate.Value - DateTime.UtcNow;
                        ModelState.AddModelError("", $"Please try again in {timeLeft.Minutes} minutes.");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Email or password are incorrect.");
                    }

                 }
                else
                {
                    ModelState.AddModelError("", "Email or password are incorrect.");
                }
            }
            return View(model); 
        }
    }
}