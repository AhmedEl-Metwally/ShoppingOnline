using Microsoft.EntityFrameworkCore;
using ShoppingOnline.Models;
using ShoppingOnline.OrderAggreate;
using System;
using System.Threading.Tasks;

namespace Shopping_online.Models
{
    public class StoreContextDBContext : DbContext
    {
        public StoreContextDBContext(DbContextOptions <StoreContextDBContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public  DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> productTypes { get; set; }
        public DbSet<CustomerBasket> CustomerBasket { get; set; }
        public DbSet<BasketItem> Basket { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethoods { get; set; }



    }   

}
