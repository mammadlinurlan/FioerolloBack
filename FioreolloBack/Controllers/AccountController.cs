using FioreolloBack.Models;
using FioreolloBack.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FioreolloBack.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid) return View();

            AppUser user = new AppUser
            {
                UserName = register.Username,
                Email = register.Email,
                Fullname = register.Fullname
            };

            IdentityResult result = await _userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }

            await _userManager.AddToRoleAsync(user, "Member");
            await _signInManager.PasswordSignInAsync(user, register.Password, true, true);


            return RedirectToAction("Index", "Home");

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

            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user.UserName, login.Password, login.RememberMe, true);

            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("", "you are blocked for 5 minutes");
                    return View();
                }
                ModelState.AddModelError("", "Username or password is incorrect");
                return View();
            }

            return RedirectToAction("Index", "Home");



        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        [Authorize]
        public async Task<IActionResult> Edit()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            EditUserVM editedUser = new EditUserVM
            {
                Username = user.UserName,
                Email = user.Email,
                Fullname = user.Fullname
            };

            return View(editedUser);

        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]



        public async Task<IActionResult> Edit(EditUserVM editUser)
        {
            if (!ModelState.IsValid) return View();

            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            EditUserVM eUser = new EditUserVM
            {
                Username = user.UserName,
                Email = user.Email,
                Fullname = user.Fullname
            };

            if (user.UserName != editUser.Username && await _userManager.FindByNameAsync(editUser.Username) != null)
            {
                ModelState.AddModelError("", $"{editUser.Username} has already taken");
                return View(eUser);
            }

            if (string.IsNullOrWhiteSpace(editUser.Confirmpassword))
            {
                user.UserName = editUser.Username;
                user.Email = editUser.Email;
                user.Fullname = editUser.Fullname;
                await _userManager.UpdateAsync(user);
            }
            else
            {
                user.UserName = editUser.Username;
                user.Email = editUser.Email;
                user.Fullname = editUser.Fullname;

                IdentityResult result = await _userManager.ChangePasswordAsync(user, editUser.Currentpassword, editUser.Password);
                if (!result.Succeeded)
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);

                    }
                    return View(eUser);
                }



            }
            //await _signInManager.PasswordSignInAsync(user, editUser.Password, true, true);
            await _signInManager.SignInAsync(user,true);

            return RedirectToAction("Index", "Home");

        }

        public IActionResult Show()
        {
            return Content(User.Identity.Name.ToString());
        }

        public IActionResult Islogin()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Details", "Flower");
            }

            return View();
        }
    }
}