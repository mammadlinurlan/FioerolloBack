using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FioreolloBack.Models
{
    public class Campaign
    {
        public int Id { get; set; }

        public int DiscountPercentage { get; set; }

        public List<Flower> Flowers { get; set; }
    }
}
