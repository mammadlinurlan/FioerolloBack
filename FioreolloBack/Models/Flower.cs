using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FioreolloBack.Models
{
    public class Flower
    {
        public int Id { get; set; }

        [StringLength(maximumLength:70)]

        public string Name { get; set; }

        public double Price { get; set; }

        public int Code { get; set; }

        [StringLength(maximumLength: 350)]
        public string Desc { get; set; }


        [StringLength(maximumLength: 15)]
        public string Weight { get; set; }

        [StringLength(maximumLength: 15)]

        public string Dimensions { get; set; }

        public bool InStock { get; set; }

        public List<FlowerCategory> FlowerCategories { get; set; }

        public List<FlowerImage> FlowerImages { get; set; }

        public int? CampaignId { get; set; }

        public Campaign Campaign { get; set; }


    }
}
