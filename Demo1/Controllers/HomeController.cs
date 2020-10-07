using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Demo1.Models;
using Microsoft.AspNetCore.Identity;

namespace Demo1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<Employee> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private static bool usedDefaultHR = false;
        private static bool usedDefaultRoles = false;

        public HomeController(ILogger<HomeController> logger, UserManager<Employee> usrManager, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _userManager = usrManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> CreateDefaultHR()
        {
            if (usedDefaultHR==false && usedDefaultRoles==true)
            {
            var user = new Employee { FirstName = "Henry", Surname = "Cavill", Email = "HR@somecompany.com", EmailConfirmed = true, UserName = "HR@somecompany.com" };
            IdentityResult result1 = await _userManager.CreateAsync(user, "Hr@1234");
            IdentityResult result2 = await _userManager.AddToRoleAsync(user, "HR");
            if (result1.Succeeded && result2.Succeeded)
                return RedirectToAction("Index");
            else
            {
                foreach (IdentityError error in result1.Errors)
                    ModelState.AddModelError("", error.Description);
                foreach (IdentityError error in result2.Errors)
                    ModelState.AddModelError("", error.Description);
            }
                usedDefaultHR = true;
            }

            return RedirectToAction("Index");



        }

        public async Task<IActionResult> CreateDefaultRoles()
        {
            if (usedDefaultRoles==false)
            {
                IdentityResult result1 = await _roleManager.CreateAsync(new IdentityRole("HR"));
                IdentityResult result2 = await _roleManager.CreateAsync(new IdentityRole("Employee"));
                usedDefaultRoles = true;
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
