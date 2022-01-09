using FioreolloBack.DAL;
using FioreolloBack.Models;
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
        public FlowerController(AppDbContext context)
        {
            _context = context;
        }
        public ActionResult Details(int id)
        {

            Flower flower = _context.Flowers.Include(f => f.FlowerImages).Include(f => f.FlowerCategories).ThenInclude(fc => fc.Category).FirstOrDefault(f => f.Id == id);


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


    }
}
