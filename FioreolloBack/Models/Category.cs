using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FioreolloBack.Models
{
    public class Category
    {
        public int Id { get; set; }

        [StringLength(maximumLength:50,ErrorMessage ="Name cannot contain more than 50 chars")]

        public string Name { get; set; }

        public List<FlowerCategory> FlowerCategories { get; set; }
    }
}
