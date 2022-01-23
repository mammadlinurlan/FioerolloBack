using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FioreolloBack.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public bool IsAcces { get; set; }

        public DateTime CreatedTime { get; set; }

        public int FlowerId { get; set; }

        public Flower Flower { get; set; }

        public AppUser AppUser { get; set; }

        public string AppUserId { get; set; }
    }
}
