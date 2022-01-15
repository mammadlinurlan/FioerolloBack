using FioreolloBack.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FioreolloBack.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Expert> Experts { get; set; }
        public DbSet<Speciality> Specialities { get; set; }

        public DbSet<Setting> Settings { get; set; }

        public DbSet<Flower> Flowers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<FlowerCategory> FlowerCategories { get; set; }

        public DbSet<Campaign> Campaigns { get; set; }

        public DbSet<FlowerImage> FlowerImages { get; set; }

        public DbSet<Slider> Sliders { get; set; }

    }
}
