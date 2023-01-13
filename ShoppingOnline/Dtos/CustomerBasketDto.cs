using ShoppingOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingOnline.Dtos
{
    public class CustomerBasketDto
    {

        public int Id { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
    }
}
