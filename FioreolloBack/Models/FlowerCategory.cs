using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FioreolloBack.Models
{
    public class FlowerCategory
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int FlowerId { get; set; }

        public Flower Flower { get; set; }
    }
}
