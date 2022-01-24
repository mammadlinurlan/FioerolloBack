using FioreolloBack.DAL;
using FioreolloBack.Models;
using FioreolloBack.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FioreolloBack.Areas.Manage.Controllers
{
    [Area("Manage")]

    public class AccountController : Controller
    {


        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;
        public AccountController(AppDbContext context,UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;

        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Login(LoginVM login)
        {

            if (!ModelState.IsValid) return View();

            AppUser user = await _userManager.FindByNameAsync(login.Username);

            if (user == null)
            {
                ModelState.AddModelError("", "username or password is incorrect");
                return View();
            }

            if (!user.IsAdmin)
            {
                ModelState.AddModelError("", "username or password is incorrect");
                return View();
            }

            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, login.Password, login.RememberMe, true);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "incorrect password or username");
                return View();

            }
            return RedirectToAction("index", "dashboard");




        }

        [Authorize(Roles ="SuperAdmin")]
        public IActionResult UserList()
        {
            
            List<AppUser> users = _userManager.Users.ToList();
           
            return View(users);
        }
        [Authorize(Roles = "SuperAdmin")]

        public async Task<IActionResult> AdminStatus(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            if (!ModelState.IsValid) return RedirectToAction("UserList", "Account");
            if (user == null)
            {
                return NotFound();
            }
            if (await _userManager.IsInRoleAsync(user, "SuperAdmin") == true)
            {
                return Content("you cannot touch superadmin!");
            }


            if (!user.IsAdmin == true)
            {
                await _userManager.AddToRoleAsync(user, "Admin");
                user.IsAdmin = true;
            }
            else
            {
                await _userManager.RemoveFromRoleAsync(user, "Admin");
                user.IsAdmin = false;
            }


          await  _context.SaveChangesAsync();
            return RedirectToAction("UserList", "Account");
        }

        //public async Task<IActionResult> Logout()
        //{
        //  await  _signInManager.SignOutAsync();
        //    return()
        //}

        //public async Task CreateRole()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
        //    await _roleManager.CreateAsync(new IdentityRole("Admin"));

        //    await _roleManager.CreateAsync(new IdentityRole("Member"));

        //}

        //public async Task CreateAdmin()
        //{
        //    AppUser user = new AppUser
        //    {
        //        UserName = "nurlanmammadli",
        //        Email = "nurlanym@code.edu.az",
        //        IsAdmin = true,
        //        Fullname = "Nurlan Senior Mammadli"

        //    };
        //    await _userManager.CreateAsync(user, "nurlan123");
        //    await _userManager.AddToRoleAsync(user, "SuperAdmin");

        //}


    }
}
