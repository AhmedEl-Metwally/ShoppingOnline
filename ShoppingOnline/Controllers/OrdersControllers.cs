using AutoMapper;
using iRely.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Octokit.Internal;
using Refit;
using ShoppingOnline.Dtos;
using ShoppingOnline.Interface;
using ShoppingOnline.Models;
using ShoppingOnline.OrderAggreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShoppingOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;

        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto)
        {
            var email = HttpContext.User.RetrieveEmailPrincipal();
            var Address = _mapper.Map<AddressDto, Address>(orderDto.ShopToAddress);
            var order = await _orderService.CreateOrderAsync(email, Address, orderDto.DeliveryMethodId, orderDto.BasketId);

            if (orderDto == null)
                return BadRequest("Prblem Creating Order");

            return Ok(order);

        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<OrderDto>>> GetOrdersForUser()
        {
            var email = HttpContext.User.RetrieveEmailPrincipal();
            var Order = await _orderService.GetOrdersForUserAsync(email);

            return Ok(_mapper.Map<IReadOnlyList<Order>, IReadOnlyList<OrderToReturnDto>>(Order));
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<OrderToReturnDto>> GetOrderByIdForUser(int id)
        {
            var email = HttpContext.User.RetrieveEmailPrincipal();
            var Order = await _orderService.GetOrderByIdAsync(id ,email);

            if (Order == null)
                return NotFound(404);



            return _mapper.Map<Order, OrderToReturnDto>(Order);
        }

        [HttpGet("deliveryMethod")]
        public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDeliveryMethods()
        {
            return Ok(await _orderService.GetDeliveryMethoodsAsync());
        }
    }
}