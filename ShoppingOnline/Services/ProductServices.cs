using Microsoft.EntityFrameworkCore;
using Shopping_online.Models;
using Shopping_online.Servies;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping_online.Services
{
    public class ProductServices : IProductServices
    {
        private readonly StoreContextDBContext _context;

        public ProductServices(StoreContextDBContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _context.ProductBrands.ToArrayAsync();
        }


     

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.ProductType)
                .Include(p => p.ProductBrand)
                .FirstOrDefaultAsync(p=>p.Id==id);   
        }


        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products
                .Include(p=>p.ProductType)
                .Include(p=>p.ProductBrand)
                .ToListAsync();
        }



        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _context.productTypes.ToListAsync();
        }
    }
}
