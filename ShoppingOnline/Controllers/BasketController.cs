using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingOnline.Interface;
using ShoppingOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketItem _basketRepository;

        public BasketController(IBasketItem basketRepository)
        {
            _basketRepository = basketRepository;
        }


        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketById(int id)
        {
            var basket = await _basketRepository.GetBasketAsync(id);

            return Ok(basket ?? new CustomerBasket(id));
        }


        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket basket)
        {
            var UpdateBasket = await _basketRepository.UpdateBasketAsync(basket);
            return Ok(UpdateBasket);
        }


        [HttpDelete]
        public async Task DeleteBasketAsync (int id)
        {
            await _basketRepository.DeleteBasketAsync(id);
        }
    }
}
