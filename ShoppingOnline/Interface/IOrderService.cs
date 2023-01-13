using ShoppingOnline.OrderAggreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingOnline.Interface
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(string buyerEmail, Address shipingAddress, int deliveryMethod, int basketId);
        Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail);
        Task<Order> GetOrderByIdAsync(int id, string buyerEmail);

        Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethoodsAsync();
    }
}
