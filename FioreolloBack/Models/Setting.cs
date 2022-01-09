using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FioreolloBack.Models
{
    public class Setting
    {

        public int Id { get; set; }

        [StringLength(maximumLength:100)]
        public string ParallaxImg { get; set; }
        [StringLength(maximumLength: 100)]
        public string Logo { get; set; }
        [StringLength(maximumLength: 100)]
        public string InstaURL { get; set; }
        [StringLength(maximumLength: 100)]
        public string FaceUrl { get; set; }

        public string BasketIcon { get; set; }

        public string SearchIcon { get; set; }

    }
}
