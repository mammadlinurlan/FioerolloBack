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

        public List<Setting> Settings { get; set; }
    }
}
