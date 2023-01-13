using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingOnline.Models
{
    public class CustomerBasket
    {
        public CustomerBasket()
        {
        }

        public CustomerBasket(int id )
        {
            Id = id;
        }

        public int Id { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();


    }
}
