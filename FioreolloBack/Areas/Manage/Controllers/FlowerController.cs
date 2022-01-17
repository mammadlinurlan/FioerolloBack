using FioreolloBack.DAL;
using FioreolloBack.Extensions;
using FioreolloBack.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FioreolloBack.Areas.Manage.Controllers
{

    [Area("Manage")]
    public class FlowerController : Controller
    {
        private readonly AppDbContext _context;
        private IWebHostEnvironment _env;

        public FlowerController(AppDbContext context , IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Flower> flowers = _context.Flowers.Include(f => f.FlowerImages).ToList();
            return View(flowers);
        }

        public IActionResult Create()
        {
            ViewBag.Campaigns = _context.Campaigns.ToList();
            ViewBag.Categories = _context.Categories.ToList();

            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Flower flower)
        {
            if (!ModelState.IsValid) return View();

            if (flower == null) return NotFound();

            flower.FlowerCategories = new List<FlowerCategory>();
            flower.FlowerImages = new List<FlowerImage>();

            if(flower.CampaignId == 0)
            {
                flower.CampaignId = null;
            }

            foreach (int id in flower.CategoryIds)
            {
                FlowerCategory flowerCategory = new FlowerCategory
                {
                    Flower = flower,
                    CategoryId = id
                };

                flower.FlowerCategories.Add(flowerCategory);
            }

            if(flower.ImageFiles.Count > 5)
            {
                ModelState.AddModelError("ImageFiles", "maximum image count is 5");
                return View();
            }

            foreach (var image in flower.ImageFiles)
            {
                if (!image.IsImage())
                {
                    ModelState.AddModelError("ImageFiles", "select image file!");
                    return View();
                }
                if (image.IsSizeOkay(2))
                {
                    ModelState.AddModelError("ImageFiles", "size must be less than 2mb");
                    return View();
                }
            }

            foreach (var image in flower.ImageFiles)
            {
                FlowerImage flowerImage = new FlowerImage
                {
                    Flower = flower,
                    Image = image.SaveImg(_env.WebRootPath, "assets/images"),
                    IsMain = flower.FlowerImages.Count < 1 ? true : false

                };

                flower.FlowerImages.Add(flowerImage);
            }

            _context.Flowers.Add(flower);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
    }
}
