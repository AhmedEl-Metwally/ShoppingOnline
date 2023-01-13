using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingOnline.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        //[MaxLength(100)]
        public string Name { get; set; }
       // [MaxLength(100)]
        public string Description { get; set; }

        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public string ProductType { get; set; }
     
        public string ProductBrand { get; set; }
        
    }
}
