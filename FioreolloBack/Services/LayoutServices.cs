
using FioreolloBack.DAL;
using FioreolloBack.Models;
using FioreolloBack.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FioreolloBack.Services
{
    public class LayoutServices
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AppUser> _userManager;
        public LayoutServices(AppDbContext context, IHttpContextAccessor httpContextAccessor,UserManager<AppUser> userManager)
        {
            _context = context;
            _httpContext = httpContextAccessor;
            _userManager = userManager;
        }

        public Setting getSettingDatas()
        {
            Setting data = _context.Settings.FirstOrDefault();
            return data;
        }
        public async  Task<BasketVM> ShowBasket()
        {
            string basket = _httpContext.HttpContext.Request.Cookies["Basket"];

            //BasketVM basketVM = new BasketVM();
            BasketVM basketData = new BasketVM
            {
                TotalPrice = 0,
                BasketItems = new List<BasketItemVM>(),
                Count = 0
            };

            if (_httpContext.HttpContext.User.Identity.IsAuthenticated)
            {
                AppUser user =await _userManager.FindByNameAsync(_httpContext.HttpContext.User.Identity.Name);
                List<BasketItem> basketItems =  _context.BasketItems.Include(b => b.AppUser).Where(b => b.AppUser.UserName == _httpContext.HttpContext.User.Identity.Name).ToList();
                foreach (BasketItem item in basketItems)
                {
                    Flower flower = _context.Flowers.Include(f => f.Campaign).FirstOrDefault(f => f.Id == item.FlowerId);
                    if (flower!=null)
                    {

                        BasketItemVM basketItem = new BasketItemVM
                        {
                            Count = item.Count,
                            Flower = flower,

                        };
                        basketItem.Price = flower.CampaignId == null ? flower.Price : flower.Price * (100 - flower.Campaign.DiscountPercentage) / 100;
                        basketData.Count++;
                        basketData.BasketItems.Add(basketItem);
                        basketData.TotalPrice += basketItem.Price * basketItem.Count;

                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(basket))
                {
                    List<BasketCookieItemVM> basketCookieItems = JsonConvert.DeserializeObject<List<BasketCookieItemVM>>(basket);

                    foreach (BasketCookieItemVM item in basketCookieItems)
                    {
                        Flower flower = _context.Flowers.FirstOrDefault(f => f.Id == item.Id);
                        if (flower != null)
                        {
                            BasketItemVM basketItem = new BasketItemVM
                            {
                                Flower = _context.Flowers.Include(f => f.Campaign).Include(f => f.FlowerImages).FirstOrDefault(f => f.Id == item.Id),
                                Count = item.Count

                            };
                            basketItem.Price = basketItem.Flower.CampaignId == null ? basketItem.Flower.Price : basketItem.Flower.Price * (100 - basketItem.Flower.Campaign.DiscountPercentage) / 100;
                            basketData.BasketItems.Add(basketItem);
                            basketData.Count++;
                            basketData.TotalPrice += basketItem.Price * basketItem.Count;
                        }
                    }

                }
                return basketData;
            }

            return basketData;
        }
    }
}