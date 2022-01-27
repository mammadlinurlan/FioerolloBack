using FioreolloBack.DAL;
using FioreolloBack.Models;
using FioreolloBack.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FioreolloBack.Controllers
{
    public class FlowerController:Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public FlowerController(AppDbContext context,UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public ActionResult Details(int id)
        {

            Flower flower = _context.Flowers.Include(f => f.FlowerImages).Include(f => f.FlowerCategories).ThenInclude(fc => fc.Category).Include(f=>f.Comments).ThenInclude(fc=>fc.AppUser).FirstOrDefault(f => f.Id == id);


            return View(flower);
        }



        public async Task<IActionResult> SetBasket(int id)
        {
            Flower flower = _context.Flowers.FirstOrDefault(f => f.Id == id);

            if (User.Identity.IsAuthenticated && User.IsInRole("Member"))
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                BasketItem basketItem = _context.BasketItems.FirstOrDefault(i => i.FlowerId == flower.Id && i.AppUserId == user.Id);
                if (basketItem==null)
                {
                    basketItem = new BasketItem
                    {
                        FlowerId = flower.Id,
                        AppUserId = user.Id,
                        Count = 1
                    };
                    _context.BasketItems.Add(basketItem);
                }
                else
                {
                    basketItem.Count++;
                }
                _context.SaveChanges();
            }
            else
            {
                string basket = HttpContext.Request.Cookies["Basket"];

                if (basket == null)
                {

                    List<BasketCookieItemVM> basketCookieItems = new List<BasketCookieItemVM>();
                    basketCookieItems.Add(new BasketCookieItemVM
                    {
                        Count = 1,
                        Id = flower.Id
                    });

                    string basketStr = JsonConvert.SerializeObject(basketCookieItems);
                    HttpContext.Response.Cookies.Append("Basket", basketStr);
                }
                else
                {
                    List<BasketCookieItemVM> basketCookieItems = JsonConvert.DeserializeObject<List<BasketCookieItemVM>>(basket);
                    BasketCookieItemVM cookieItem = basketCookieItems.FirstOrDefault(c => c.Id == flower.Id);
                    if (cookieItem == null)
                    {
                        cookieItem = new BasketCookieItemVM
                        {
                            Id = flower.Id,
                            Count = 1
                        };
                        basketCookieItems.Add(cookieItem);
                    }
                    else
                    {
                        cookieItem.Count++;

                    }
                    string basketStr = JsonConvert.SerializeObject(basketCookieItems);
                    HttpContext.Response.Cookies.Append("Basket", basketStr);
                }
            }


           

          




        




            return RedirectToAction("Index", "Home");
        }

        public IActionResult ShowBasket()
        {
            string strBasket = HttpContext.Request.Cookies["Basket"];
            if (!string.IsNullOrEmpty(strBasket))
            {
                List<BasketCookieItemVM> basket = JsonConvert.DeserializeObject<List<BasketCookieItemVM>>(strBasket);
                return Json(basket);
            };

            return Content("basket is empty") ;
        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment(Comment comment)
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (!ModelState.IsValid) return RedirectToAction("Details", "Flower", new { id = comment.FlowerId });
            if (!_context.Flowers.Any(f => f.Id == comment.FlowerId))
            {
                return NotFound();
            }
            Comment cmnt = new Comment
            {
                AppUserId = user.Id,
                FlowerId = comment.FlowerId,
                CreatedTime = DateTime.Now,
                Text = comment.Text
            };
            _context.Comments.Add(cmnt);
            _context.SaveChanges();
            return RedirectToAction("Details", "Flower", new { id = cmnt.FlowerId });

        }

        public async Task<IActionResult> DeleteComment(int id)
        {
            AppUser user =await _userManager.FindByNameAsync(User.Identity.Name);
            if (!ModelState.IsValid) return RedirectToAction("Details", "Flower");
            if (!_context.Comments.Any(c =>c.Id == id  && c.AppUserId == user.Id)) return NotFound();
            Comment comment = _context.Comments.FirstOrDefault(c => c.Id == id && c.AppUserId == user.Id);
            _context.Comments.Remove(comment);
            _context.SaveChanges();
            return RedirectToAction("Details", "Flower", new { id = comment.FlowerId });



        }

        //[Authorize]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AddComment ([FromBody]Comment comment)
        //{
        //    AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
        //    if (!ModelState.IsValid) return BadRequest(400);
        //    if (!_context.Flowers.Any(f => f.Id == comment.FlowerId))
        //    {
        //        return NotFound();
        //    }
        //    Comment cmnt = new Comment
        //    {
        //        AppUserId = user.Id,
        //        FlowerId = comment.FlowerId,
        //        CreatedTime = DateTime.Now,
        //        Text = comment.Text
        //    };
        //    _context.Comments.Add(cmnt);
        //    _context.SaveChanges();
        //    return Ok(new {name = user.Fullname, time = cmnt.CreatedTime, text = cmnt.Text});
        //}
    }
}
