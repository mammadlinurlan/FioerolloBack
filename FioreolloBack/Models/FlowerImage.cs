using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FioreolloBack.Models
{
    public class FlowerImage
    {
        public int Id { get; set; }

        [StringLength(maximumLength:100)]
        public string Image { get; set; }


        public bool IsMain { get; set; }

        public int FlowerId { get; set; }

        public Flower Flower { get; set; }
    }
}
