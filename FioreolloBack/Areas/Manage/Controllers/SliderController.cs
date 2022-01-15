using FioreolloBack.DAL;
using FioreolloBack.Extensions;
using FioreolloBack.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FioreolloBack.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private IWebHostEnvironment _env;

        public SliderController(AppDbContext context,IWebHostEnvironment env)
        {
            _env = env;
            _context = context;
        }
        public IActionResult Index()
        {
            List<Slider> sliders = _context.Sliders.ToList();
            return View(sliders);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Slider slider)
        {
            if (!ModelState.IsValid) return View();

            if (slider.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Select image!");
                return View();

            }

            if (!slider.ImageFile.IsImage())
            {
                ModelState.AddModelError("ImageFile", "Select image file you donkey!");
                return View();
            }

            if (slider.ImageFile.IsSizeOkay(2))
            {
                ModelState.AddModelError("ImageFile", "Image size must be less than 2mb");
                return View();

            }

            slider.Image = slider.ImageFile.SaveImg(_env.WebRootPath, "assets/images");
            _context.Sliders.Add(slider);
            _context.SaveChanges();


            return RedirectToAction(nameof(Index));
        }
    }
}
