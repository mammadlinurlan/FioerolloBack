using FioreolloBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FioreolloBack.ViewModels
{
    public class BasketItemVM
    {
        public Flower Flower { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
    }
}
