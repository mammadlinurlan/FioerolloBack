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
            List<Flower> flowers = _context.Flowers.Include(f => f.FlowerImages).Include(f=>f.Comments).ToList();
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


        public IActionResult Edit(int id)
        {

            ViewBag.Campaigns = _context.Campaigns.ToList();
            ViewBag.Categories = _context.Categories.ToList();
            Flower flower = _context.Flowers.Include(f => f.FlowerCategories).Include(f => f.FlowerImages).FirstOrDefault(f => f.Id == id);

            return View(flower);
        }

        public IActionResult Edit(Flower flower)
        {

            ViewBag.Campaigns = _context.Campaigns.ToList();
            ViewBag.Categories = _context.Categories.ToList();
            Flower existedFlower = _context.Flowers.Include(f => f.FlowerCategories).Include(f => f.FlowerImages).FirstOrDefault(f => f.Id == flower.Id);

            if (!ModelState.IsValid) return View();

            if(existedFlower == null)
            {
                return NotFound();
            }

            if(flower.ImageFiles != null)
            {
                foreach (var item in flower.ImageFiles)
                {
                    if (!item.IsImage())
                    {
                        ModelState.AddModelError("ImageFiles", "must be image");
                        return View(existedFlower);

                    }
                    if (item.IsSizeOkay(2))
                    {
                        ModelState.AddModelError("ImageFiles", "must be less than 2mb");
                        return View(existedFlower);

                    }
                }

                List<FlowerImage> removableImages = existedFlower.FlowerImages.Where(f => !flower.ImageIds.Contains(f.Id)).ToList();
                existedFlower.FlowerImages.RemoveAll(f => removableImages.Any(ri => ri.Id == f.Id));
                foreach (var item in removableImages)
                {
                    Helpers.Helper.DeleteImg(_env.WebRootPath, "assets/images", item.Image);
                }

                foreach (var item in flower.ImageFiles)
                {
                    FlowerImage flowerImage = new FlowerImage
                    {
                        FlowerId = existedFlower.Id,
                        IsMain = false,
                        Image = item.SaveImg(_env.WebRootPath, "assets/images")
                    };
                    existedFlower.FlowerImages.Add(flowerImage);
                }

                List<FlowerCategory> removableCategories = existedFlower.FlowerCategories.Where(fc => !flower.CategoryIds.Contains(fc.Id)).ToList();
                existedFlower.FlowerCategories.RemoveAll(f => removableCategories.Any(rc => rc.Id == f.Id));

                foreach (var categoryId in flower.CategoryIds)
                {
                    FlowerCategory flowerCategory = existedFlower.FlowerCategories.FirstOrDefault(f => f.CategoryId == categoryId);
                    if(flowerCategory == null)
                    {
                        FlowerCategory flowerCategory1 = new FlowerCategory
                        {
                            CategoryId = categoryId,
                            FlowerId = existedFlower.Id

                        };
                        existedFlower.FlowerCategories.Add(flowerCategory1);
                    }
                }
            }


            existedFlower.Name = flower.Name;
            existedFlower.Price = flower.Price;

            existedFlower.Code = flower.Code;
            existedFlower.Desc = flower.Desc;
            existedFlower.Dimensions = flower.Dimensions;
            existedFlower.Weight = flower.Weight;
            existedFlower.InStock = flower.InStock;
           if(flower.CampaignId == 0)
            {
                flower.Campaign = null;
            }

            existedFlower.Campaign = flower.Campaign;

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));







        }

        public IActionResult Comments(int Flowerid)
        {
            if(!_context.Comments.Any(c=>c.FlowerId == Flowerid))
            {
                return RedirectToAction("Index", "Flower");
            }

            List<Comment> comments = _context.Comments.Where(c => c.FlowerId == Flowerid).Include(c=>c.AppUser).ToList();


            return View(comments);
        }

        public IActionResult CommentStatus(int id)
        {
            if (!_context.Comments.Any(c => c.Id == id))
            {
                return RedirectToAction("Index", "Flower");
            }

            Comment comment = _context.Comments.FirstOrDefault(c => c.Id == id);
            comment.IsAcces = comment.IsAcces ? false : true;
            _context.SaveChanges();

            return RedirectToAction("Comments", "Flower", new { Flowerid = comment.FlowerId });

        }
    }
}
