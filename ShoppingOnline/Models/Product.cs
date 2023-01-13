using ShoppingOnline.Dtos;
using System;
using System.ComponentModel.DataAnnotations;

namespace Shopping_online.Models
{
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public  ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public int ProductBrandId { get; set; }

        internal ProductDto select(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}
