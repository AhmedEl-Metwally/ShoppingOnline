using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using Shopping_online.Models;
using ShoppingOnline.Interface;
using ShoppingOnline.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace ShoppingOnline.Services
{
    public class BasketItemServices : IBasketItem
    {
        private readonly StoreContextDBContext _context;
        public BasketItemServices (StoreContextDBContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteBasketAsync(int basketId)
        {
            var CustomerBasket = await _context.CustomerBasket.FindAsync(basketId);

            _context.CustomerBasket.Remove(CustomerBasket);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<CustomerBasket> GetBasketAsync(int basketId)
        {

            return await _context.CustomerBasket.FindAsync(basketId);
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            var CustomerBasket = await _context.CustomerBasket.FindAsync(basket);

            _context.CustomerBasket.Update(CustomerBasket);
            await _context.SaveChangesAsync();
            return basket;

        }
    }
}
