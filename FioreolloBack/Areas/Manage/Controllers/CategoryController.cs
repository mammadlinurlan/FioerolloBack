using FioreolloBack.DAL;
using FioreolloBack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FioreolloBack.Areas.Manage.Controllers
{
    [Area("Manage")]

    public class CategoryController:Controller
    {

        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
       
        public IActionResult Index()
        {
            List<Category> model = _context.Categories.Include(c => c.FlowerCategories).ToList();

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            Category existed = _context.Categories.FirstOrDefault(f => f.Id == id);
            return View(existed);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public  IActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Category existed = _context.Categories.FirstOrDefault(f => f.Id == category.Id);
            if (existed == null)
            {
                return NotFound();
            }

            Category samename = _context.Categories.FirstOrDefault(f => f.Name.ToLower().Trim() == category.Name.ToLower().Trim());
            if (samename != null)
            {
                ModelState.AddModelError("", "This category is already exists");
                return View();
            }

            existed.Name = category.Name;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

    }
}
