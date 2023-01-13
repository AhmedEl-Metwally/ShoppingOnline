using ShoppingOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingOnline.Interface
{
    public interface IBasketItem
    {
        Task<CustomerBasket> GetBasketAsync(int basketId);
        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);
        Task<bool> DeleteBasketAsync(int basketId);

    }
}
