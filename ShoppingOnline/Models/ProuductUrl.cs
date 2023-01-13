using AutoMapper;
using Microsoft.Extensions.Configuration;
using Shopping_online.Models;
using ShoppingOnline.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingOnline.Models
{
    public class ProuductUrl : IValueResolver<Product, ProductDto, string>
    {
        private readonly IConfiguration _config;
        public ProuductUrl(IConfiguration config)
        {
            _config = config;

        }

        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _config["ApiUrl"] + source.PictureUrl; 
            }

            return null;
        }
    }
}
