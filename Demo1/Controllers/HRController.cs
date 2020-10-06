using Demo1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo1.Controllers
{
    [Authorize(Roles ="HR")]
    public class HRController: Controller
    {

        private UserManager<Employee> userManager;
        private RoleManager<IdentityRole> roleManager;

        public HRController(RoleManager<IdentityRole> roleMgr,UserManager<Employee> usrMgr)
        {
            userManager = usrMgr;
            roleManager = roleMgr;
        }

        public IActionResult Index()
        {
            return View(userManager.Users);
        }

        public ViewResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                Employee employee = new Employee
                {
                    UserName = user.Email,
                    FirstName = user.FirstName,
                    Surname = user.Surname,
                    Email = user.Email
                };

                IdentityResult result1 = await userManager.CreateAsync(employee, user.Password);
                IdentityResult result2 = await userManager.AddToRoleAsync(employee, user.Role);
                if (result1.Succeeded && result2.Succeeded)
                    return RedirectToAction("Index");
                else
                {
                    foreach (IdentityError error in result1.Errors)
                        ModelState.AddModelError("", error.Description);
                    foreach (IdentityError error in result2.Errors)
                        ModelState.AddModelError("", error.Description);
                }

            }
            return View(user);
        }
    }
}
