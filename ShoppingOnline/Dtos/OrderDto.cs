using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingOnline.Dtos
{
    public class OrderDto
    {
        public int BasketId { get; set; }
        public int DeliveryMethodId { get; set; }
        public AddressDto ShopToAddress { get; set; }
    }
}
