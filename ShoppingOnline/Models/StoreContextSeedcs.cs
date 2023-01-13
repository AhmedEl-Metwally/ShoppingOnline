using Microsoft.Extensions.Logging;
using Shopping_online.Models;
using ShoppingOnline.OrderAggreate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Windows.ApplicationModel.Store;
using Windows.Services.Store;
using ProductType = Shopping_online.Models.ProductType;

namespace ShoppingOnline.Models
{
    public class StoreContextSeedcs
    {
        public static async Task SeedAsync(StoreContextDBContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                var brandsData =
                        File.ReadAllText("../ShoppingOnline/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach (var item in brands)
                    {
                        context.ProductBrands.Add(item);
                    }
                    await context.SaveChangesAsync();

                }

                if (!context.productTypes.Any())
                {
                    var TypesData =
                        File.ReadAllText("../ShoppingOnline/SeedData/Types.json");
                    var Types = JsonSerializer.Deserialize<List<ProductType>>(TypesData);

                    foreach (var item in Types)
                    {
                        context.productTypes.Add(item);
                    }

                    await context.SaveChangesAsync();

                }

                if (!context.Products.Any())
                {
                    var ProductsData =
                        File.ReadAllText("../ShoppingOnline/SeedData/products.json");
                    var Types = JsonSerializer.Deserialize<List<Product>>(ProductsData);

                    foreach (var item in Types)
                    {
                        context.Products.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.DeliveryMethoods.Any())
                {
                    var dmData =
                        File.ReadAllText("../ShoppingOnline/SeedData/delivery.json");
                    var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(dmData);

                    foreach (var item in methods)
                    {
                        context.DeliveryMethoods.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

            }
            catch(Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeedcs>();
                logger.LogError(ex.Message);
            }



    }   }
}
