using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FioreolloBack.Models
{
    public class Expert
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }

        public int SpecialityId { get; set; }

        public string Description { get; set; }
        public Speciality Speciality { get; set; }
    }
}
