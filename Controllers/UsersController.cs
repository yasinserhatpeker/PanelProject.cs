using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PanelProject.Models;
using PanelProject.ViewModels;

namespace PanelProject.Controllers
{
    public class UsersController : Controller
    {
        private UserManager<AppUser> _userManager;

        public UsersController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(_userManager.Users);
        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateViewModel model)
        {
            if (model == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = model.UserName,
                    FullName=model.FullName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                };
                if (user == null)
                {
                    return NotFound();
                }
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (IdentityError err in  result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }


            }
            return View(model);
        }
        

    }
}