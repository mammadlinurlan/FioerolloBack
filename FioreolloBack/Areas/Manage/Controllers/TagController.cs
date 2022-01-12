using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FioreolloBack.Areas.Manage.Controllers
{

    public class TagController:Controller
    {
        [Area("Manage")]

        public IActionResult Index()
        {
            return View();
        }


             
    }
}
