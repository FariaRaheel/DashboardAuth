using DashboardAuth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.ContentModel;
using System;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Net.WebRequestMethods;
using System.Reflection.Metadata;
using System.Security.Principal;

namespace DashboardAuth.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Users()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }
        public IActionResult Edit(string id)
        {
            var user = _userManager.FindByIdAsync(id).Result;
            if (user == null)
            {
                return NotFound();
            }
            return View(user);


        }
        [HttpPost]
        public IActionResult Edit (IdentityUser model)
        {
            {
                if (ModelState.IsValid)
                {
                    
                    var user = _userManager.FindByIdAsync(model.Id).Result;
                    user.UserName = model.UserName;
                    user.Email = model.Email;

                    var result = _userManager.UpdateAsync(user).Result;

                    if (result.Succeeded)
                    {
                 
                        return RedirectToAction("Users");
                    }
                
                else
                {
              
                    ModelState.AddModelError("", "Failed to update the user.");
                }
            }
            return View(model);
        }

      
    }
    public IActionResult Delete (string id)
        { var user=_userManager.FindByIdAsync(id).Result;
            if (user == null)
            {
                return NotFound();

            }
            return View(user);
        }

        [HttpPost]
    public IActionResult Delete (IdentityUser model)
        { 
        {
                if (ModelState.IsValid)
                {
                    var user = _userManager.FindByIdAsync(model.Id).Result;
                    user.UserName = model.UserName;
                    user.Email = model.Email;

                    var result = _userManager.DeleteAsync(user).Result;
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Users");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Failed to Delete the User");

                    }
                }
                return View(model);
            }
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
        }
}