using ShoppingOnline.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShoppingOnline.OrderAggreate
{
    public class OrdersWithItemsAndOrderingSpecification : BaseSpecification<Order>
    {
        public OrdersWithItemsAndOrderingSpecification(string email) : base (o =>o.BuyerEmail == email)
        {
            AddInculube(o => o.OrderItems);
            AddInculube(o => o.DeliveryMethod);
            AddOrderByDescending(o => o.OrderDate);

        }

        public OrdersWithItemsAndOrderingSpecification(int id, string email) 
            : base(o => o.Id == id && o.BuyerEmail == email)
        {
            AddInculube(o => o.OrderItems);
            AddInculube(o => o.DeliveryMethod);
        }
    }
}
