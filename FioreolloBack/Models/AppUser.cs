﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FioreolloBack.Models
{
    public class AppUser:IdentityUser
    {
        public string Fullname { get; set; }
        public bool IsAdmin { get; set; }

        public List<BasketItem> BasketItems { get; set; }
    }
}
