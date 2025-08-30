using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PanelProject.Models;

namespace PanelProject.Controllers
{
    public class RolesController : Controller
    {
        private readonly RoleManager<AppRole> _managerRole;

        public RolesController(RoleManager<AppRole> managerRole)
        {
            _managerRole = managerRole;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AppRole model)
        {
            if (ModelState.IsValid)
            {
                var result = await _managerRole.CreateAsync(model);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }
            return View(model); 
        }
    }
}