using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PanelProject.Models;
using PanelProject.ViewModels;

namespace PanelProject.Controllers
{
    public class UsersController : Controller
    {
        private UserManager<AppUser> _userManager;

        private RoleManager<AppRole> _roleManager;

        public UsersController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;

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
                    FullName = model.FullName,
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
                foreach (IdentityError err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }


            }
            return View(model);
        }

        public async Task<IActionResult> Edit(string Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
           

            var user = await _userManager.FindByIdAsync(Id);
            
            if (user != null)
            {
                ViewBag.Roles = await _roleManager.Roles.Select(i => i.Name).ToListAsync();

                return View(new EditViewModel
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Email = user.Email,
                    UserName = user.UserName,
                    SelectedRole = await _userManager.GetRolesAsync(user)


                });
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditViewModel model, string Id)
        {
            if (Id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    user.FullName = model.FullName;
                    user.Email = model.Email;
                    user.UserName = model.UserName;


                    var result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded || !string.IsNullOrEmpty(model.Password))
                    {
                        await _userManager.RemovePasswordAsync(user);
                        await _userManager.AddPasswordAsync(user, model.Password);
                    }
                    if (result.Succeeded)
                    {
                       await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));
                        if (model.SelectedRole != null)
                        {
                            await _userManager.AddToRolesAsync(user, model.SelectedRole);
                        }
                        return RedirectToAction("Index");
                    }
                    foreach (var err in result.Errors)
                    {
                        ModelState.AddModelError("", err.Description);
                    }
                }

            }
            ViewBag.Roles = await _roleManager.Roles.Select(i => i.Name).ToListAsync();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var user = await _userManager.FindByIdAsync(Id);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }

       
        }

      
    }
