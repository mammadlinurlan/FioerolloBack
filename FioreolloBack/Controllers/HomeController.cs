using FioreolloBack.DAL;
using FioreolloBack.Models;
using FioreolloBack.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FioreolloBack.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Categories=_context.Categories.ToList(),
                Experts=_context.Experts.Include(e=>e.Speciality).ToList(),
                  Settings=_context.Settings.FirstOrDefault(),
                  Flowers=_context.Flowers.Include(f=>f.FlowerImages).Include(f=>f.FlowerCategories).ThenInclude(f=>f.Category).Include(f=>f.Campaign).ToList()
            };

            return View(homeVM);
        }

    }
}
