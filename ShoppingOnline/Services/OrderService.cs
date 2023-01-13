using Shopping_online.Models;
using ShoppingOnline.Interface;
using ShoppingOnline.Models;
using ShoppingOnline.OrderAggreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingOnline.Services
{
    public class OrderService : IOrderService
    {
        
        private readonly IBasketItem _BasketItem;
        private readonly IUnitOfWork _unitOfWork;

        //private object _basketRepo;

        public OrderService( IBasketItem BasketItem , IUnitOfWork unitOfWork)
        {
             
            _BasketItem = BasketItem;
            _unitOfWork = unitOfWork;
        }

        public async Task<Order> CreateOrderAsync(string buyerEmail, Address shipingAddress, int deliveryMethodId, int basketId)
        {
            var basket = await _BasketItem.GetBasketAsync(basketId);
            var items = new List<OrderItem>();
            foreach (var item in basket.Items)
            {
                var ProductItem = await _unitOfWork.Repository<Product>().GetByIdAsync(item.Id);
                var itemOrdered = new ProductItemOrdered(ProductItem.Id, ProductItem.Name, ProductItem.PictureUrl);
                var OrderItem = new OrderItem(itemOrdered, ProductItem.Price, item.Quantity);
                items.Add(OrderItem);
            }

            var deliveryMethod = await _unitOfWork.Repository<DeliveryMethod>().GetByIdAsync(deliveryMethodId);

            var subtotal = items.Sum(item => item.Price * item.Quantity);

            var Order = new Order(items, buyerEmail, shipingAddress, deliveryMethod, subtotal);
            _unitOfWork.Repository<Order>().Add(Order);
            var result = await _unitOfWork.Complete();
            if (result <= 0)
                return null;
            await _BasketItem.DeleteBasketAsync(basketId);

            return Order;

        }

        public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethoodsAsync()
        {
            return await _unitOfWork.Repository<DeliveryMethod>().ListAllAsync();

        }

        public async Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
        {
            var spec = new OrdersWithItemsAndOrderingSpecification(id , buyerEmail);
            return await _unitOfWork.Repository<Order>().GetEntityWithSpes(spec);
        }

        public async Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
        {
            var spec = new OrdersWithItemsAndOrderingSpecification(buyerEmail);
            return await _unitOfWork.Repository<Order>().ListAsync(spec);
                
        }
    }
}
