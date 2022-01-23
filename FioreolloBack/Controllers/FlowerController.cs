using FioreolloBack.DAL;
using FioreolloBack.Models;
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



        public IActionResult SetBasket(int id)
        {
            Flower flower = _context.Flowers.FirstOrDefault(f => f.Id == id);

            List<Flower> flowers;

           string basket = HttpContext.Request.Cookies["Basket"];

            if (basket == null)
            {
                flowers = new List<Flower>();

                flowers.Add(flower);

            }
            else
            {
                flowers = JsonConvert.DeserializeObject<List<Flower>>(basket);
                flowers.Add(flower);
            }




            string basketStr = JsonConvert.SerializeObject(flowers);
            HttpContext.Response.Cookies.Append("Basket", basketStr);




            return RedirectToAction("Index", "Home");
        }

        public IActionResult ShowBasket()
        {
            string strBasket = HttpContext.Request.Cookies["Basket"];

            List<Flower> flowers = JsonConvert.DeserializeObject<List<Flower>>(strBasket);

            return Json(flowers);
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
