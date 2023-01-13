using Shopping_online.Models;
using ShoppingOnline.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShoppingOnline.Models
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(string sort, int? BrandId, int? TypeId)
            : base(x =>
                   (!BrandId.HasValue || x.ProductBrandId == BrandId) &&
                   (!TypeId.HasValue || x.ProductTypeId == TypeId)
                   )
        {
            AddInculube(x => x.ProductType);
            AddInculube(x => x.ProductBrand);
            AddOrderBy(x => x.Name);


            if(!string.IsNullOrEmpty(sort))
            {
                switch(sort)
                {
                    case "PriceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "PriceDesc":
                        AddOrderByDescending(n => n.Name);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;


                }
            }

        }

        public ProductsWithTypesAndBrandsSpecification(int id)
            :base(x=>x.Id ==id)
        {
            AddInculube(x => x.ProductType);
            AddInculube(x => x.ProductBrand);
        }


    }
}
