using FioreolloBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FioreolloBack.ViewModels
{
    public class HomeVM
    {
        public List<Speciality> Specialities { get; set; }

        public List<Expert> Experts { get; set; }

        public Setting Settings { get; set; }

        public List<Category> Categories { get; set; }
        public List<Flower> Flowers { get; set; }
    }
}
